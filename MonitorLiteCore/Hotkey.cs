using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    public class Hotkey
    {

        private static uint WM_HOTKEY = 0x312;

        private static int id = 0;
        private uint _mod;
        private Keys _key;
      
        private Thread msgLoop;
        private Hotkey(uint mod, Keys key)
        {
            id++;
            _mod = mod;
            _key = key;
            
            msgLoop = new Thread(MessageLoop);
            msgLoop.SetApartmentState(ApartmentState.STA);
            msgLoop.Start();
        }

        public event EventHandler Trigger;

        private void MessageLoop()
        {
            bool flag;

            int currId = id;
            do
            {
                Thread.Sleep(3000);
                flag = NativeMethods.RegisterHotKey(IntPtr.Zero, currId, _mod, (uint)_key);
            } while (!flag);
            try
            {
                Message m = default(Message);
                while (NativeMethods.GetMessage(ref m, IntPtr.Zero, 0, 0))
                {

                    if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == currId)
                    {
                        if (Trigger != null)
                            Trigger(this, EventArgs.Empty);
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            
        }

        public void Close()
        {
         
            if (msgLoop.IsAlive)
            {
                msgLoop.Abort();
                //msgLoop.Join();
                

            }
        }

             

        public static Hotkey Create(uint mod, Keys key)
        {
            return new Hotkey(mod, key);
        }


    }
}

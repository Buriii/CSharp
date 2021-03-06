using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackHole {

    class TestNestedMonitor {

        public static BlackHole blackhole = new BlackHole();

        public static void Main() {
            Thread t1 = new Thread(delegate() {
                Console.WriteLine(blackhole.get().ToString());
            });

            Thread t2 = new Thread(delegate() {
                blackhole.put("Sonne, Licht, irgendetwas...");
            });

            Console.WriteLine("Wir starten die Untersuchung...");
            t1.Start();
            t2.Start();
            t1.Join();
            Console.WriteLine("Was ist passiert...");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;
using ParkingLot.Classes;

namespace ParkingLot.Classes
{
    class ParkingLotManager
    {
        public void RunParkingLot()
        {
            ParkingLot lot = new ParkingLot();
            Space a = new Space( 0, 1, SpaceSize.COMPACT);
            Space b = new Space(0, 2, SpaceSize.COMPACT);
            Space c = new Space(0, 3, SpaceSize.COMPACT);

            a.setRight(b);
            b.setRight(c);
            c.setRight(new NullSpace());

            a.setLeft(new NullSpace());
            b.setLeft(a);
            c.setLeft(b);
            Space aa = new Space(1, 1, SpaceSize.COMPACT);
            Space bb = new Space(1, 2, SpaceSize.COMPACT);
            Space cc = new Space(1, 3, SpaceSize.COMPACT);

            aa.setRight(bb);
            bb.setRight(cc);
            cc.setRight(new NullSpace());

            aa.setLeft(new NullSpace());
            bb.setLeft(aa);
            cc.setLeft(bb);

            Space aaa = new Space(2, 1, SpaceSize.COMPACT);
            Space bbb = new Space(2, 2, SpaceSize.COMPACT);
            Space ccc = new Space(2, 3, SpaceSize.COMPACT);

            aaa.setRight(bbb);
            bbb.setRight(ccc);
            ccc.setRight(new NullSpace());

            aaa.setLeft(new NullSpace());
            bbb.setLeft(aaa);
            ccc.setLeft(bbb);

            List<SpaceInterface> newSpaces = new List<SpaceInterface> {a,b,c,aa,bb,cc,aaa,bbb,ccc};

            foreach(SpaceInterface s in newSpaces)
            {

                if (s.getLeft() is NullSpace) { System.Console.Write(Environment.NewLine); }
                System.Console.Write(s.getLeft().Print());
                     System.Console.Write(s.Print());
                System.Console.Write(s.getRight().Print());
                if (s.getRight() is NullSpace) { System.Console.Write(Environment.NewLine); }
            }

        }
    }
}

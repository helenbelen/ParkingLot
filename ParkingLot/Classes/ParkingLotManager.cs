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
        public string RunParkingLot()
        {
            ParkingLot lot = new ParkingLot();
            Space a = new Space( 0, 1, SpaceSize.COMPACT);
            Space b = new Space(0, 2, SpaceSize.COMPACT);
            Space c = new Space(0, 3, SpaceSize.COMPACT);
            a.setLeft(b);
            b.setLeft(a);
            b.setRight(c);
            c.setLeft(b);

            Space aa = new Space(1, 1, SpaceSize.COMPACT);
            Space bb = new Space(1, 2, SpaceSize.COMPACT);
            Space cc = new Space(1, 3, SpaceSize.COMPACT);

            aa.setLeft(bb);
            bb.setLeft(aa);
            bb.setRight(cc);
            cc.setLeft(bb);

            Space aaa = new Space(2, 1, SpaceSize.COMPACT);
            Space bbb = new Space(2, 2, SpaceSize.COMPACT);
            Space ccc = new Space(2, 3, SpaceSize.COMPACT);

            aaa.setRight(bbb);
            bbb.setLeft(aaa);
            bbb.setRight(ccc);
            ccc.setLeft(bbb);

            List<SpaceInterface> newSpaces = new List<SpaceInterface> {a,b,c,aa,bb,cc,aaa,bbb,ccc};

            return newSpaces[0].Print();

        }
    }
}

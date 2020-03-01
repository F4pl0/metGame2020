using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public GameObject L;
    public GameObject R;
    public GameObject T;
    public GameObject B;

    public GameObject TL;
    public GameObject TR;
    public GameObject BL;
    public GameObject BR;
    public GameObject TB;
    public GameObject LR;

    public GameObject TBL;
    public GameObject TBR;
    public GameObject TLR;
    public GameObject BRL;

    public GameObject TBLR;

    public GameObject GetRoom(string name) {
        switch (name) {
            case "L":
                return L;
            case "R":
                return R;
            case "T":
                return T;
            case "B":
                return B;
            case "TL":
                return TL;
            case "LT":
                return TL;
            case "TR":
                return TR;
            case "RT":
                return TR;
            case "BL":
                return BL;
            case "LB":
                return BL;
            case "BR":
                return BR;
            case "RB":
                return BR;
            case "TB":
                return TB;
            case "BT":
                return TB;
            case "LR":
                return LR;
            case "RL":
                return LR;

            case "TBL":
                return TBL;
            case "TLB":
                return TBL;
            case "LBT":
                return TBL;
            case "LTB":
                return TBL;
            case "BTL":
                return TBL;
            case "BLT":
                return TBL;

            case "TBR":
                return TBR;
            case "TRB":
                return TBR;
            case "RBT":
                return TBR;
            case "RTB":
                return TBR;
            case "BTR":
                return TBR;
            case "BRT":
                return TBR;

            case "TRL":
                return TLR;
            case "TLR":
                return TLR;
            case "LRT":
                return TLR;
            case "LTR":
                return TLR;
            case "RTL":
                return TLR;
            case "RLT":
                return TLR;

            case "BRL":
                return BRL;
            case "BLR":
                return BRL;
            case "LRB":
                return BRL;
            case "LBR":
                return BRL;
            case "RBL":
                return BRL;
            case "RLB":
                return BRL;
                
            case "TBRL":
                return TBLR;
            case "TBLR":
                return TBLR;
            case "TLRB":
                return TBLR;
            case "TLBR":
                return TBLR;
            case "TRBL":
                return TBLR;
            case "TRLB":
                return TBLR;

            case "BTRL":
                return TBLR;
            case "BTLR":
                return TBLR;
            case "BLRT":
                return TBLR;
            case "BLTR":
                return TBLR;
            case "BRTL":
                return TBLR;
            case "BRLT":
                return TBLR;

            case "LTBR":
                return TBLR;
            case "LTRB":
                return TBLR;
            case "LRBT":
                return TBLR;
            case "LRTB":
                return TBLR;
            case "LBTR":
                return TBLR;
            case "LBRT":
                return TBLR;

            case "RTBL":
                return TBLR;
            case "RTLB":
                return TBLR;
            case "RLBT":
                return TBLR;
            case "RLTB":
                return TBLR;
            case "RBTL":
                return TBLR;
            case "RBLT":
                return TBLR;
        }

        return null;
    }
}

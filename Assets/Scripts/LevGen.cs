using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevGen : MonoBehaviour
{

    public Room room;



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




    public int maxRooms = 10;
    public int minRooms = 5;

    public string[][] map;
    private int roomsLeft = 0;
    void Start() {
        room = new Room();
        room.L = L;
        room.R = R;
        room.T = T;
        room.B = B;

        room.TL = TL;
        room.TR = TR;
        room.BL = BL;
        room.BR = BR;
        room.TB = TB;
        room.LR = LR;

        room.TBL = TBL;
        room.TBR = TBR;
        room.TLR = TLR;
        room.BRL = BRL;

        room.TBLR = TBLR;

        //Init
        map = new string[maxRooms*2][];
        for (int i = 0; i < maxRooms * 2; i++) {
            map[i] = new string[maxRooms * 2];
        }
        roomsLeft = Random.Range(minRooms, maxRooms);

        genRoom(maxRooms, maxRooms);
        
        checkRooms(maxRooms, maxRooms);

        for (int i = 0; i < map.Length; i++) {
            for(int j = 0; j < map[i].Length; j++) {
                if(map[i][j] != null) {
                    map[i][j] = map[i][j].Remove(map[i][j].IndexOf("C"), 1);
                    if (room.GetRoom(map[i][j]) == null) {
                    } else {
                        Instantiate(
                    room.GetRoom(map[i][j]),
                    new Vector3(i * 25f - 25f*maxRooms, 0f, j * 25f - 25f * maxRooms),
                    Quaternion.identity
                    );
                    }
                }
            }
        }
    }

    void genRoom(int x, int y) {

        string roomStr = "";

        string roomsToConnectTo = "N";
        if(map[x-1][y] != null) {
            if(map[x - 1][y].Contains("R")) {
                roomsToConnectTo += ",L";
            }
        } if (map[x + 1][y] != null) {
            if(map[x + 1][y].Contains("L")) {
                roomsToConnectTo += ",R";
            }
        } if (map[x][y - 1] != null) {
            if(map[x][y - 1].Contains("T")) {
                roomsToConnectTo += "B";
            }
        } if (map[x][y + 1] != null) {
            if(map[x][y + 1].Contains("B")) {
                roomsToConnectTo += "T";
            }
        }
        string[] connRooms = roomsToConnectTo.Split(',');

        int maxAvailableRooms = roomsLeft - connRooms.Length + 1;
        int minAvailableRooms = connRooms.Length - 1;
        if (maxAvailableRooms < minAvailableRooms) {
            maxAvailableRooms = minAvailableRooms;
        }

        for(int i = 1; i < connRooms.Length; i++) {
            roomStr += connRooms[i];
        }

        if (roomsLeft < 1) {
            if(roomStr.Length > 1) {
                map[x][y] = roomStr;
            }
            return;
        }

        if (maxAvailableRooms > 4) {
            maxAvailableRooms = 4;
        }
        maxAvailableRooms -= minAvailableRooms;

        if(maxAvailableRooms > 0) {
            int passToAdd = 0;
            passToAdd = Random.Range(1, maxAvailableRooms + 1);

            while(passToAdd > 0) {
                switch(Random.Range(1, 5)) {
                    case 1:
                        if (!roomStr.Contains("T")) {
                            roomStr += "T";
                            passToAdd--;
                        }
                        break;
                    case 2:
                        if (!roomStr.Contains("B")) {
                            roomStr += "B";
                            passToAdd--;
                        }
                        break;
                    case 3:
                        if (!roomStr.Contains("L")) {
                            roomStr += "L";
                            passToAdd--;
                        }
                        break;
                    case 4:
                        if (!roomStr.Contains("R")) {
                            roomStr += "R";
                            passToAdd--;
                        }
                        break;
                }
            }
        }
        if(roomStr.Length < 1) {
            return;
        }
        roomsLeft--;
        map[x][y] = roomStr;

        if (map[x - 1][y] == null && roomStr.Contains("L")) {
            genRoom(x - 1, y);
        }
        if (map[x + 1][y] == null && roomStr.Contains("R")) {
            genRoom(x + 1, y);
        }
        if (map[x][y - 1] == null && roomStr.Contains("B")) {
            genRoom(x, y - 1);
        }
        if (map[x][y + 1] == null && roomStr.Contains("T")) {
            genRoom(x, y + 1);
        }


    }

    void checkRooms(int x, int y) {
        map[x][y] += "C";
       
        if (map[x - 1][y] == null && map[x][y].Contains("L")) {
            map[x][y] = map[x][y].Remove(map[x][y].IndexOf("L"), 1);
        }
        if (map[x + 1][y] == null && map[x][y].Contains("R")) {
            map[x][y] = map[x][y].Remove(map[x][y].IndexOf("R"), 1);
        }
        if (map[x][y - 1] == null && map[x][y].Contains("B")) {
            map[x][y] = map[x][y].Remove(map[x][y].IndexOf("B"), 1);
        }
        if (map[x][y + 1] == null && map[x][y].Contains("T")) {
            map[x][y] = map[x][y].Remove(map[x][y].IndexOf("T"), 1);
        }

        if (map[x - 1][y] != null) {
            if (!map[x - 1][y].Contains("C")) {
                checkRooms(x-1, y);
            }
        }
        if (map[x + 1][y] != null) {
            if (!map[x + 1][y].Contains("C")) {
                checkRooms(x + 1, y);
            }
        }
        if (map[x][y - 1] != null) {
            if (!map[x][y - 1].Contains("C")) {
                checkRooms(x, y - 1);
            }
        }
        if (map[x][y + 1] != null) {
            if (!map[x][y + 1].Contains("C")) {
                checkRooms(x, y + 1);
            }
        }
    }
}
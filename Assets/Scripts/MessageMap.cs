using System.IO;
using System;
using System.Collections.Generic;

public static class MessageMap
{
    static private Dictionary<int, string> map =
        new Dictionary<int, string> ();

    public static void Install() {
        map[1002] = "agent_login_ack";
        map[1004] = "room_join_ack";
        map[1005] = "room_join_ntf";
        map[1008] = "room_leave_ntf";
        map[1010] = "room_move_ntf";
    }

    public static string GetEventName(int cmd) {
        return map[cmd];
    }
};

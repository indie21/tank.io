using System.IO;
using System;
using System.Collections.Generic;

public static class MessageMap
{
    static private Dictionary<int, string> map = new Dictionary<int, string> ();

    public static void Install() {
        map[1002] = "agent_login_ack";
        map[1004] = "room_join_ack";
    }

    public static string GetEventName(int cmd) {
        return map[cmd];
    }
};

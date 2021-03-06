//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/payload.proto
namespace proto.payload
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"agent_login_req")]
  public partial class agent_login_req : global::ProtoBuf.IExtensible
  {
    public agent_login_req() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"agent_login_ack")]
  public partial class agent_login_ack : global::ProtoBuf.IExtensible
  {
    public agent_login_ack() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"vector3")]
  public partial class vector3 : global::ProtoBuf.IExtensible
  {
    public vector3() {}
    
    private float _x;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float x
    {
      get { return _x; }
      set { _x = value; }
    }
    private float _y;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float y
    {
      get { return _y; }
      set { _y = value; }
    }
    private float _z;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"z", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float z
    {
      get { return _z; }
      set { _z = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"transform")]
  public partial class transform : global::ProtoBuf.IExtensible
  {
    public transform() {}
    
    private vector3 _position;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"position", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public vector3 position
    {
      get { return _position; }
      set { _position = value; }
    }
    private vector3 _rotation;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"rotation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public vector3 rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }
    private vector3 _movement;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"movement", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public vector3 movement
    {
      get { return _movement; }
      set { _movement = value; }
    }
    private float _speed;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"speed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float speed
    {
      get { return _speed; }
      set { _speed = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"player")]
  public partial class player : global::ProtoBuf.IExtensible
  {
    public player() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private byte[] _name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] name
    {
      get { return _name; }
      set { _name = value; }
    }
    private transform _trans;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"trans", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public transform trans
    {
      get { return _trans; }
      set { _trans = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"box")]
  public partial class box : global::ProtoBuf.IExtensible
  {
    public box() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int type
    {
      get { return _type; }
      set { _type = value; }
    }
    private int _hp;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"hp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int hp
    {
      get { return _hp; }
      set { _hp = value; }
    }
    private transform _trans;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"trans", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public transform trans
    {
      get { return _trans; }
      set { _trans = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_join_req")]
  public partial class room_join_req : global::ProtoBuf.IExtensible
  {
    public room_join_req() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private byte[] _name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_join_ack")]
  public partial class room_join_ack : global::ProtoBuf.IExtensible
  {
    public room_join_ack() {}
    
    private int _room_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"room_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int room_id
    {
      get { return _room_id; }
      set { _room_id = value; }
    }
    private int _self_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"self_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int self_id
    {
      get { return _self_id; }
      set { _self_id = value; }
    }
    private readonly global::System.Collections.Generic.List<player> _players = new global::System.Collections.Generic.List<player>();
    [global::ProtoBuf.ProtoMember(3, Name=@"players", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<player> players
    {
      get { return _players; }
    }
  
    private readonly global::System.Collections.Generic.List<box> _boxs = new global::System.Collections.Generic.List<box>();
    [global::ProtoBuf.ProtoMember(4, Name=@"boxs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<box> boxs
    {
      get { return _boxs; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_join_ntf")]
  public partial class room_join_ntf : global::ProtoBuf.IExtensible
  {
    public room_join_ntf() {}
    
    private player _player;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public player player
    {
      get { return _player; }
      set { _player = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_leave_req")]
  public partial class room_leave_req : global::ProtoBuf.IExtensible
  {
    public room_leave_req() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_leave_ntf")]
  public partial class room_leave_ntf : global::ProtoBuf.IExtensible
  {
    public room_leave_ntf() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_move_req")]
  public partial class room_move_req : global::ProtoBuf.IExtensible
  {
    public room_move_req() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private transform _trans;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"trans", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public transform trans
    {
      get { return _trans; }
      set { _trans = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"room_move_ntf")]
  public partial class room_move_ntf : global::ProtoBuf.IExtensible
  {
    public room_move_ntf() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private transform _trans;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"trans", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public transform trans
    {
      get { return _trans; }
      set { _trans = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"agent_logout_req")]
  public partial class agent_logout_req : global::ProtoBuf.IExtensible
  {
    public agent_logout_req() {}
    
    private int _player_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"player_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int player_id
    {
      get { return _player_id; }
      set { _player_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"agent_logout_ack")]
  public partial class agent_logout_ack : global::ProtoBuf.IExtensible
  {
    public agent_logout_ack() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
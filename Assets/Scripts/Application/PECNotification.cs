// this class gives statis access to the events strings
public class Notification
{
    // Game Controller notifications
    public const string SphereCollision = "sphere.collision";
    public const string SphereGenerate = "sphere.generate";
    public const string ShootSphere = "sphere.shoot";
    public const string DeleteSphere = "sphere.delete";

    public const string SphereTypeUpdated = "sphere.type.updated";

    public const string SphereTypeRecentIdUpdate = "sphere.type.recentid.update";
    public const string SphereTypeRecentIdUpdateOsc = "sphere.type.recentid.update.osc";

    public const string SphereTypeUpdate = "sphere.type.update";
    public const string SphereTypeUpdateOsc = "sphere.type.update.osc";

    public const string SphereTypeLiveUpdate = "sphere.type.update.live";
    public const string SphereTypeLiveUpdateOsc = "sphere.type.update.live.osc";

    public const string KeyboardInput = "keyboard.input";

    public const string GravityUpdateOsc = "gravity.update.osc";
    public const string GravityUpdate = "gravity.update";

    // not used or implemented yet
    public const string SurfaceTypeUpdate = "surface.type.update";
    public const string RoomInfoGetOsc = "get.room.info";
    public const string PlayerShootSpeed = "player.shoot.speed";
    public const string PlayerShootSpeedOsc = "player.shoot.speed.osc";

}
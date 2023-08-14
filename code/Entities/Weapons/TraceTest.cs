using Sandbox;

namespace MyGame;
public class TraceTest : Weapon
{
	public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";
	public override string WorldModelPath => "weapons/rust_pistol/rust_pistol.vmdl";
	public override float PrimaryAttackDelay => 0.1f;
	public override float PrimaryReloadDelay => 3.0f;
	public override int MaxPrimaryAmmo => 17;
	public override AmmoType PrimaryAmmoType => AmmoType.Pistol;
	public override void PrimaryAttack()
	{
		var b = GatewayTrace.Ray( Owner.AimRay.Position + (Owner.AimRay.Forward * 50), Owner.AimRay.Position + (Owner.AimRay.Forward*400) );
		b.StartRotation = Owner.AimRay.Forward.EulerAngles.ToRotation();
		var tr = b.Run();
		foreach( var traceresult in tr.Results )
		{
			DebugOverlay.Line( traceresult.StartPosition, traceresult.EndPosition, 5, false );
		}

		DebugOverlay.Line( tr.StartPosition, tr.EndPosition, Color.Red, 5, false );
		DebugOverlay.Line( tr.StartPosition, tr.StartPosition + (tr.StartRotation.Forward * 10), Color.Blue, 5, false );
		DebugOverlay.Line( tr.StartPosition, tr.StartPosition + (tr.StartRotation.Up * 10), Color.Green, 5, false );
		DebugOverlay.Line( tr.EndPosition, tr.EndPosition + (tr.EndRotation.Forward * 10), Color.Blue, 5, false );
		DebugOverlay.Line( tr.EndPosition, tr.EndPosition + (tr.EndRotation.Up * 10), Color.Green, 5, false );
	}

	public override void SecondaryAttack()
	{
		var pl = Owner as Player;
		var tr = GatewayTrace.Box( pl.Hull, pl.Position, pl.Position ).Ignore(pl).Run();

		foreach ( var traceresult in tr.Results )
		{
			DebugOverlay.Line( traceresult.StartPosition, traceresult.EndPosition, 5, false );
		}
		base.SecondaryAttack();
	}
}

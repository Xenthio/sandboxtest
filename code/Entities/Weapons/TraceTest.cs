﻿using Sandbox;

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
		var tr = b.Run();
		foreach( var traceresult in tr.Results )
		{
			DebugOverlay.Line( traceresult.StartPosition, traceresult.EndPosition, 5, false );
		}

		DebugOverlay.Line( tr.StartPosition, tr.EndPosition, Color.Red, 5, false );
	}
}
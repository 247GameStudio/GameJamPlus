using Godot;
using Godot.Collections;
using System;

public partial class iLoadableOnEnd : iLoadableConsumer
{

	[Export]
	public Array<Stat> onEndStatConsumed;

	[Export]
	public Array<float> onEndStatConsumedAmount;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	protected override void OnComplete()
	{
		EndConsume();
		EmitSignal("onComplete");
		Reset();


	}

	protected override bool CheckValid()
	{
		bool valid = true;

		for(int i =0;i<statsConsumed.Count;++i)
		{
			if(statsConsumed[i].currentValue - rateConsumed[i] <= statsConsumed[i].minValue)
			{
				valid=false;
			}

		}

		for(int j=0;j<onEndStatConsumed.Count;++j)
		{
			if(onEndStatConsumed[j].currentValue - onEndStatConsumedAmount[j] <= onEndStatConsumed[j].minValue)
			{
				valid = false;
			}
		}


		return valid;

	}

	protected void EndConsume()
	{
		for(int i=0;i<onEndStatConsumed.Count;++i)
		{
			onEndStatConsumed[i].currentValue -= onEndStatConsumedAmount[i];
			onEndStatConsumed[i].Update();
			
		}
	}

}

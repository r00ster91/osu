// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Edit;
using osu.Game.Rulesets.Osu.Edit.Masks.HitCircle;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.Objects.Drawables;
using osu.Game.Tests.Visual;
using OpenTK;

namespace osu.Game.Rulesets.Osu.Tests
{
    public class TestCaseHitCircleSelectionMask : HitObjectSelectionMaskTestCase
    {
        private readonly DrawableHitCircle drawableObject;

        public TestCaseHitCircleSelectionMask()
        {
            var hitCircle = new HitCircle { Position = new Vector2(256, 192) };
            hitCircle.ApplyDefaults(new ControlPointInfo(), new BeatmapDifficulty { CircleSize = 2 });

            Add(drawableObject = new DrawableHitCircle(hitCircle));
        }

        protected override SelectionMask CreateMask() => new HitCircleSelectionMask(drawableObject);
    }
}

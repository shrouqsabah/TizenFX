﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.Animation;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/Animation")]
    class PublicAnimationTest
    {
        private const string tag = "NUITEST";

        private void OnFinished(object sender, EventArgs e)
        {
            tlog.Debug(tag, "OnFinished : Finished!");
        }

        private void OnProgressReached(object sender, EventArgs e)
        {
            tlog.Debug(tag, "OnProgressReached : ProgressReached!");
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Animation constructor")]
        [Property("SPEC", "Tizen.NUI.Animation.Animation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationConstructor()
        {
            tlog.Debug(tag, $"AnimationConstructor START");

            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.Finished += OnFinished;
            testingTarget.Finished -= OnFinished;

            testingTarget.ProgressReached += OnProgressReached;
            testingTarget.ProgressReached -= OnProgressReached;

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation DownCast")]
        [Property("SPEC", "Tizen.NUI.Animation.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDownCast()
        {
            tlog.Debug(tag, $"AnimationDownCast START");

            using (Animation ani = new Animation(300))
            {
                var testingTarget = Animation.DownCast(ani);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnimationDownCast END (OK)");
        }
        
		[Test]
        [Category("P1")]
        [Description("Animation GetCurrentProgress")]
        [Property("SPEC", "Tizen.NUI.Animation.GetCurrentProgress M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationGetCurrentProgress()
        {
            tlog.Debug(tag, $"AnimationGetCurrentProgress START");

            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            try
			{
                testingTarget.SetCurrentProgress(0.3f);
                
                var result = testingTarget.GetCurrentProgress();
                tlog.Debug(tag, "Current progress : " + result);
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: Failed!");
            }

            testingTarget.Dispose();
            
            tlog.Debug(tag, $"AnimationGetCurrentProgress END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Animation GetSpeedFactor")]
        [Property("SPEC", "Tizen.NUI.Animation.GetSpeedFactor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationGetSpeedFactor()
        {
            tlog.Debug(tag, $"AnimationGetSpeedFactor START");

            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            try
			{
                testingTarget.SetSpeedFactor(0.3f);

			    var result = testingTarget.GetSpeedFactor();
                tlog.Debug(tag, "Speed factor : " + result);
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: Failed!");
            }

            testingTarget.Dispose();
            
            tlog.Debug(tag, $"AnimationGetSpeedFactor END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("Animation SetPlayRange")]
        [Property("SPEC", "Tizen.NUI.Animation.SetPlayRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSetPlayRange()
        {
            tlog.Debug(tag, $"AnimationSetPlayRange START");

            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            try
			{
                Vector2 val = new Vector2(0.0f, 10.0f);
                testingTarget.SetPlayRange(val);

			    var result = testingTarget.GetPlayRange();
                tlog.Debug(tag, "PlayRange : " + result);
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSetPlayRange END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("Animation PlayRange")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayRange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayRange()
        {
            tlog.Debug(tag, $"AnimationPlayRange START");
            
            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            using (Vector2 vec = new Vector2(0.0f, 1.0f))
			{
                try
			    {
                    testingTarget.PlayRange = vec;

                    var result = testingTarget.PlayRange;
                    Assert.AreEqual(0.0f, result.X, "Should be equal!");
                    Assert.AreEqual(1.0f, result.Y, "Should be equal!");
			    }
			    catch(Exception e)
                {
                    Assert.Fail("Catch exception: " + e.Message.ToString());
                }
			}

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayRange END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Animation DownCast")]
        [Property("SPEC", "Tizen.NUI.Animation.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDownCastWithNullHandle()
        {
            tlog.Debug(tag, $"AnimationDownCastWithNullHandle START");

            BaseHandle handle = null;

            try
            {
                Animation.DownCast(handle);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"AnimationDownCastWithNullHandle END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Animation Duration. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDurationGet()
        {
            tlog.Debug(tag, $"AnimationDurationGet START");

            var testingTarget = new Animation(2000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.Duration;
            Assert.AreEqual(2000, result, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDurationGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Duration. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDurationSet()
        {
            tlog.Debug(tag, $"AnimationDurationSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.Duration = 2000;
            var result = testingTarget.Duration;
            Assert.AreEqual(2000, result, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDurationSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation DefaultAlphaFunction. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.DefaultAlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDefaultAlphaFunctionGet()
        {
            tlog.Debug(tag, $"AnimationDefaultAlphaFunctionGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.DefaultAlphaFunction;
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(result, "should be an instance of AlphaFunction class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDefaultAlphaFunctionGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation DefaultAlphaFunction. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.DefaultAlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDefaultAlphaFunctionSet()
        {
            tlog.Debug(tag, $"AnimationDefaultAlphaFunctionSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce);
            var result = testingTarget.DefaultAlphaFunction;
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(result, "should be an instance of AlphaFunction class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDefaultAlphaFunctionSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation State")]
        [Property("SPEC", "Tizen.NUI.Animation.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationState()
        {
            tlog.Debug(tag, $"AnimationState START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.State;
            Assert.AreEqual("Stopped", result.ToString(), "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation LoopCount. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationLoopCountGet()
        {
            tlog.Debug(tag, $"AnimationLoopCountGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.LoopCount;
            Assert.IsTrue(1 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationLoopCountGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation LoopCount. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationLoopCountSet()
        {
            tlog.Debug(tag, $"AnimationLoopCountSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.LoopCount = 3;
            var result = testingTarget.LoopCount;
            Assert.IsTrue(3 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationLoopCountSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Looping. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.Looping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationLoopingGet()
        {
            tlog.Debug(tag, $"AnimationLoopingGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.Looping;
            Assert.IsFalse(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationLoopingGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Looping. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.Looping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationLoopingSet()
        {
            tlog.Debug(tag, $"AnimationLoopingSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.Looping = true;
            var result = testingTarget.Looping;
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationLoopingSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation EndAction. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.EndAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationEndActionGet()
        {
            tlog.Debug(tag, $"AnimationEndActionGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.EndAction;
            Assert.IsTrue(EndActions.Cancel == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationEndActionGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation EndAction. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.EndAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationEndActionSet()
        {
            tlog.Debug(tag, $"AnimationEndActionSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.Discard;
            var result = testingTarget.EndAction;
            Assert.IsTrue(EndActions.Discard == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationEndActionSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation CurrentLoop")]
        [Property("SPEC", "Tizen.NUI.Animation.CurrentLoop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationCurrentLoop()
        {
            tlog.Debug(tag, $"AnimationCurrentLoop START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.CurrentLoop;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationCurrentLoop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation DisconnectAction. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.DisconnectAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDisconnectActionGet()
        {
            tlog.Debug(tag, $"AnimationDisconnectActionGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.DisconnectAction;
            Assert.IsTrue(EndActions.StopFinal == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDisconnectActionGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation DisconnectAction. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.DisconnectAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationDisconnectActionSet()
        {
            tlog.Debug(tag, $"AnimationDisconnectActionSet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DisconnectAction = Animation.EndActions.Cancel;
            var result = testingTarget.EndAction;
            Assert.IsTrue(EndActions.Cancel == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationDisconnectActionSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation CurrentProgress. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.CurrentProgress A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationCurrentProgressGet()
        {
            tlog.Debug(tag, $"AnimationCurrentProgressGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.CurrentProgress;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationCurrentProgressGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation CurrentProgress. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.CurrentProgress A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationCurrentProgressSet()
        {
            tlog.Debug(tag, $"AnimationCurrentProgressSet START");

            var testingTarget = new Animation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.CurrentProgress = 0.3f;
            float result = testingTarget.CurrentProgress;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationCurrentProgressSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation SpeedFactor. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.SpeedFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSpeedFactorGet()
        {
            tlog.Debug(tag, $"AnimationSpeedFactorGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.SpeedFactor;
            Assert.IsTrue(1 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSpeedFactorGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation SpeedFactor. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.SpeedFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSpeedFactorSet()
        {
            tlog.Debug(tag, $"AnimationSpeedFactorSet START");

            var testingTarget = new Animation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.SpeedFactor = 2;
            float result = testingTarget.SpeedFactor;
            Assert.IsTrue(2 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSpeedFactorSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation PlayRange. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayRange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayRangeGet()
        {
            tlog.Debug(tag, $"AnimationPlayRangeGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.PlayRange;
            Assert.IsTrue(0 == result.X);
            Assert.IsTrue(1 == result.Y);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayRangeGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation PlayRange. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayRange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayRangeSet()
        {
            tlog.Debug(tag, $"AnimationPlayRangeSet START");

            var testingTarget = new Animation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.PlayRange = new RelativeVector2(0.3f, 0.5f);
            var result = testingTarget.PlayRange;
            Assert.IsTrue(0.3f == result.X);
            Assert.IsTrue(0.5f == result.Y);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayRangeSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation ProgressNotification. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.ProgressNotification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationProgressNotificationGet()
        {
            tlog.Debug(tag, $"AnimationProgressNotificationGet START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            var result = testingTarget.ProgressNotification;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationProgressNotificationGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation ProgressNotification. Set")]
        [Property("SPEC", "Tizen.NUI.Animation.ProgressNotification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationProgressNotificationSet()
        {
            tlog.Debug(tag, $"AnimationProgressNotificationSet START");

            var testingTarget = new Animation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.ProgressNotification = 0.3f;
            var result = testingTarget.ProgressNotification;
            Assert.IsTrue(0.3f == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationProgressNotificationSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Stop. Get")]
        [Property("SPEC", "Tizen.NUI.Animation.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationStop()
        {
            tlog.Debug(tag, $"AnimationStop START");

            var testingTarget = new Animation();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.Stop(EndActions.Discard);
            var result = testingTarget.EndAction;
            Assert.IsTrue(EndActions.Discard == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationStop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateBy")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateBy()
        {
            tlog.Debug(tag, $"AnimationAnimateBy START");

            View view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.IsTrue(0 == view.Position.X);
            Assert.IsTrue(0 == view.Position.Y);

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            testingTarget.AnimateBy(view, "Position", new Position(100, 150));
            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.Play();

            Assert.IsTrue(100 == view.Position.X);
            Assert.IsTrue(150 == view.Position.Y);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationAnimateBy END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByWithNullView()
        {
            tlog.Debug(tag, $"AnimationAnimateByWithNullView START");

            View view = null;

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));

            try
            {
                testingTarget.AnimateBy(view, "Position", new Position(100, 150));
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByWithNullView END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByNullProperty()
        {
            tlog.Debug(tag, $"AnimationAnimateByNullProperty START");

            View view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.IsTrue(0 == view.Position.X);
            Assert.IsTrue(0 == view.Position.Y);

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            
            try
            {
                string property = null;
                testingTarget.AnimateBy(view, property, new Position(100, 150));
            }
            catch (ArgumentNullException)
            {
                Window.Instance.Remove(view);
                view.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByNullProperty END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByNullObject()
        {
            tlog.Debug(tag, $"AnimationAnimateByNullObject START");

            View view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.IsTrue(0 == view.Position.X);
            Assert.IsTrue(0 == view.Position.Y);

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));

            try
            {
                testingTarget.AnimateBy(view, "Position", null);
            }
            catch (ArgumentNullException)
            {
                Window.Instance.Remove(view);
                view.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByNullObject END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateBy. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByWithStartTimeAndEndTime()
        {
            tlog.Debug(tag, $"AnimationAnimateByWithStartTimeAndEndTime START");

            var view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.AreEqual(0, view.Position.X, "sholud be equal.");
            Assert.AreEqual(0, view.Position.Y, "sholud be equal.");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            testingTarget.AnimateBy(view, "Position", new Position(100, 150), 0, 0);
            testingTarget.AnimateBy(view, "Position", new Position(300, 200), 0, 300);

            testingTarget.Play();
            Assert.AreEqual(400, view.Position.X, "sholud be equal.");
            Assert.AreEqual(350, view.Position.Y, "sholud be equal.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationAnimateByWithStartTimeAndEndTime END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByWithStartEndTimeAndNullView()
        {
            tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullView START");

            View view = null;

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));

            try
            {
                testingTarget.AnimateBy(view, "Position", new Position(100, 150), 0, 300);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullView END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByWithStartEndTimeAndNullString()
        {
            tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullString START");

            var view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.AreEqual(0, view.Position.X, "sholud be equal.");
            Assert.AreEqual(0, view.Position.Y, "sholud be equal.");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));

            try
            {
                testingTarget.AnimateBy(view, null, new Position(100, 150), 0, 300);
            }
            catch (ArgumentNullException)
            {
                Window.Instance.Remove(view);
                view.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullString END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Animation AnimateBy. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateByWithStartEndTimeAndNullObject()
        {
            tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullObject START");

            var view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.AreEqual(0, view.Position.X, "sholud be equal.");
            Assert.AreEqual(0, view.Position.Y, "sholud be equal.");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));

            try
            {
                testingTarget.AnimateBy(view, "position", null, 0, 300);
            }
            catch (ArgumentNullException)
            {
                Window.Instance.Remove(view);
                view.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationAnimateByWithStartEndTimeAndNullObject END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateTo")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateTo()
        {
            tlog.Debug(tag, $"AnimationAnimateTo START");

            var view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.AreEqual(0, view.Position.X, "sholud be equal.");
            Assert.AreEqual(0, view.Position.Y, "sholud be equal.");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            testingTarget.AnimateTo(view, "Position", new Position(100, 150));
            
            testingTarget.Play();
            Assert.AreEqual(100, view.Position.X, "sholud be equal.");
            Assert.AreEqual(150, view.Position.Y, "sholud be equal.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationAnimateTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateTo. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateToWithStartTimeAndEndTime()
        {
            tlog.Debug(tag, $"AnimationAnimateToWithStartTimeAndEndTime START");

            var view = new View()
            {
                Position = new Position(0, 0)
            };
            Window.Instance.Add(view);
            Assert.AreEqual(0, view.Position.X, "sholud be equal.");
            Assert.AreEqual(0, view.Position.Y, "sholud be equal.");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            testingTarget.AnimateTo(view, "Position", new Position(100, 150), 0, 0);
            testingTarget.AnimateTo(view, "Position", new Position(300, 200), 0, 300);

            testingTarget.Play();
            Assert.AreEqual(300, view.Position.X, "sholud be equal.");
            Assert.AreEqual(200, view.Position.Y, "sholud be equal.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationAnimateToWithStartTimeAndEndTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation PlayAnimateTo")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayAnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayAnimateTo()
        {
            tlog.Debug(tag, $"AnimationPlayAnimateTo START");

            View view = new View()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan,
            };

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
            
            testingTarget.PropertyList.Add("SizeWidth");
            testingTarget.DestValueList.Add("80");
            testingTarget.StartTimeList.Add(0);
            testingTarget.EndTimeList.Add(1500);

            try
            {
                testingTarget.PlayAnimateTo(view);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayAnimateTo END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Animation PlayAnimateTo")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayAnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayAnimateToNullTarget()
        {
            tlog.Debug(tag, $"AnimationPlayAnimateToNullTarget START");

            var testingTarget = new Animation(1500);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            ImageView view = null;

            try
            {
                testingTarget.PlayAnimateTo(view);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimationPlayAnimateToNullTarget END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateBetween")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateBetween()
        {
            tlog.Debug(tag, $"AnimationAnimateBetween START");

            View view = new View()
            {
                Opacity = 0.0f
            };

            var keyFrames = new KeyFrames();
            Assert.IsNotNull(keyFrames, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(keyFrames, "should be an instance of Animation class!");
            keyFrames.Add(0.0f, 1.0f);

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.AnimateBetween(view, "Opacity", keyFrames);

            testingTarget.Dispose();
            keyFrames.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"AnimationAnimateBetween END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateBetween. With startTime and endTime")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateBetweenWithStartTimeAndEndTime()
        {
            tlog.Debug(tag, $"AnimationAnimateBetweenWithStartTimeAndEndTime START");

            View view = new View()
            {
                Opacity = 0.0f
            };

            var keyFrames = new KeyFrames();
            Assert.IsNotNull(keyFrames, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(keyFrames, "should be an instance of Animation class!");
            keyFrames.Add(0.0f, 1.0f);

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.AnimateBetween(view, "Opacity", keyFrames, 0, 600);

            testingTarget.Dispose();
            keyFrames.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"AnimationAnimateBetweenWithStartTimeAndEndTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimateBetween. With KeyFrames and TimePeriod ")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimateBetweenWithPropertyKeyFramesandTimePeriod()
        {
            tlog.Debug(tag, $"AnimationAnimateBetweenWithPropertyKeyFramesandTimePeriod START");

            View view = new View()
            {
                Opacity = 0.0f
            };

            var keyFrames = new KeyFrames();
            Assert.IsNotNull(keyFrames, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(keyFrames, "should be an instance of Animation class!");
            keyFrames.Add(0.0f, 1.0f);

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            
            try
            {
                testingTarget.AnimateBetween(view, "Opacity", keyFrames);
                testingTarget.AnimateBetween(view, "Opacity", keyFrames, 0, 600);
                testingTarget.AnimateBetween(view, "Opacity", keyFrames,0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            keyFrames.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"AnimationAnimateBetweenWithPropertyKeyFramesandTimePeriod END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimatePath")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimatePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimatePath()
        {
            tlog.Debug(tag, $"AnimationAnimatePath START");

            View view = new View()
            { 
                Size = new Size(200, 300)
            };

            Path path = new Path();
            PropertyArray points = new PropertyArray();
            points.PushBack(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));
            points.PushBack(new PropertyValue(new Vector3(0.9f, 0.3f, 0.0f)));
            path.Points = points;

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.AnimatePath(view, path, new Vector3(0.0f, 0.6f, 1.2f));

            testingTarget.Dispose();
            points.Dispose();
            path.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"AnimationAnimatePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation AnimatePath. With start time and end time")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimatePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationAnimatePathWithStartTimeAndEndTime()
        {
            tlog.Debug(tag, $"AnimationAnimatePathWithStartTimeAndEndTime START");

            View view = new View()
            {
                Size = new Size(200, 300)
            };

            Path path = new Path();
            PropertyArray points = new PropertyArray();
            points.PushBack(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));
            points.PushBack(new PropertyValue(new Vector3(0.9f, 0.3f, 0.0f)));
            path.Points = points;

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.AnimatePath(view, path, new Vector3(0.0f, 0.6f, 1.2f), 0, 600);

            testingTarget.Dispose();
            points.Dispose();
            path.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"AnimationAnimatePathWithStartTimeAndEndTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Play")]
        [Property("SPEC", "Tizen.NUI.Animation.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlay()
        {
            tlog.Debug(tag, $"AnimationPlay START");

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            try
            {
                testingTarget.Play();
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation PlayFrom")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayFrom()
        {
            tlog.Debug(tag, $"AnimationPlayFrom START");

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            try
            {
                testingTarget.PlayFrom(0.3f);
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayFrom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation PlayAfter")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayAfter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationPlayAfter()
        {
            tlog.Debug(tag, $"AnimationPlayAfter START");

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            try
            {
                testingTarget.PlayAfter(300);
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationPlayAfter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Clear")]
        [Property("SPEC", "Tizen.NUI.Animation.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationClear()
        {
            tlog.Debug(tag, $"AnimationClear START");

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;
            testingTarget.Play();

            try
            {
                testingTarget.Clear();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }


            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animation Show")]
        [Property("SPEC", "Tizen.NUI.Animation.Show M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationShow()
        {
            tlog.Debug(tag, $"AnimationShow START");

            var testingTarget = new Animation(600);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animation>(testingTarget, "should be an instance of Animation class!");

            testingTarget.EndAction = Animation.EndActions.StopFinal;

            using (View view = new View() { Color = Color.Cyan, })
            {
                testingTarget.Show(view, 200);
                testingTarget.Hide(view, 300);
            }

            testingTarget.Play();
            testingTarget.Stop();
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationShow END (OK)");
        }
    }
}

﻿using System;

namespace OpenBve {
	internal static class TrainManager {

		// axle
		internal struct Axle {
			internal TrackManager.TrackFollower Follower;
			internal bool CurrentWheelSlip;
		}

		// coupler
		internal struct Coupler {
			internal double MinimumDistanceBetweenCars;
			internal double MaximumDistanceBetweenCars;
		}

		// sections
		internal struct Section {
			internal ObjectManager.AnimatedObject[] Elements;
			internal bool Overlay;
		}

		// cars
		internal struct Door {
			internal int Direction;
			internal double State;
		}
		internal struct AccelerationCurve {
			internal double StageZeroAcceleration;
			internal double StageOneSpeed;
			internal double StageOneAcceleration;
			internal double StageTwoSpeed;
			internal double StageTwoExponent;
		}
		internal enum CarBrakeType {
			ElectromagneticStraightAirBrake = 0,
			ElectricCommandBrake = 1,
			AutomaticAirBrake = 2
		}
		internal enum EletropneumaticBrakeType {
			None = 0,
			ClosingElectromagneticValve = 1,
			DelayFillingControl = 2
		}
		internal enum AirBrakeHandleState {
			Invalid = -1,
			Release = 0,
			Lap = 1,
			Service = 2,
		}
		internal struct AirBrakeHandle {
			internal AirBrakeHandleState Driver;
			internal AirBrakeHandleState Security;
			internal AirBrakeHandleState Actual;
			internal AirBrakeHandleState DelayedValue;
			internal double DelayedTime;
		}
		internal enum AirBrakeType { Main, Auxillary }
		internal struct CarAirBrake {
			internal AirBrakeType Type;
			internal bool AirCompressorEnabled;
			internal double AirCompressorMinimumPressure;
			internal double AirCompressorMaximumPressure;
			internal double AirCompressorRate;
			internal double MainReservoirCurrentPressure;
			internal double MainReservoirEqualizingReservoirCoefficient;
			internal double MainReservoirBrakePipeCoefficient;
			internal double EqualizingReservoirCurrentPressure;
			internal double EqualizingReservoirNormalPressure;
			internal double EqualizingReservoirServiceRate;
			internal double EqualizingReservoirEmergencyRate;
			internal double EqualizingReservoirChargeRate;
			internal double BrakePipeCurrentPressure;
			internal double BrakePipeNormalPressure;
			internal double BrakePipeFlowSpeed;
			internal double BrakePipeChargeRate;
			internal double BrakePipeServiceRate;
			internal double BrakePipeEmergencyRate;
			internal double AuxillaryReservoirCurrentPressure;
			internal double AuxillaryReservoirMaximumPressure;
			internal double AuxillaryReservoirChargeRate;
			internal double AuxillaryReservoirBrakePipeCoefficient;
			internal double AuxillaryReservoirBrakeCylinderCoefficient;
			internal double BrakeCylinderCurrentPressure;
			internal double BrakeCylinderEmergencyMaximumPressure;
			internal double BrakeCylinderServiceMaximumPressure;
			internal double BrakeCylinderEmergencyChargeRate;
			internal double BrakeCylinderServiceChargeRate;
			internal double BrakeCylinderReleaseRate;
			internal double BrakeCylinderSoundPlayedForPressure;
			internal double StraightAirPipeCurrentPressure;
			internal double StraightAirPipeReleaseRate;
			internal double StraightAirPipeServiceRate;
			internal double StraightAirPipeEmergencyRate;
		}
		internal struct CarHoldBrake {
			internal double CurrentAccelerationOutput;
			internal double NextUpdateTime;
			internal double UpdateInterval;
		}
		internal struct CarConstSpeed {
			internal double CurrentAccelerationOutput;
			internal double NextUpdateTime;
			internal double UpdateInterval;
		}
		internal struct CarReAdhesionDevice {
			internal double UpdateInterval;
			internal double MaximumAccelerationOutput;
			internal double ApplicationFactor;
			internal double ReleaseInterval;
			internal double ReleaseFactor;
			internal double NextUpdateTime;
			internal double TimeStable;
		}
		internal struct CarSpecs {
			/// motor
			internal bool IsMotorCar;
			internal AccelerationCurve[] AccelerationCurves;
			internal double AccelerationCurvesMultiplier;
			internal double AccelerationCurveMaximum;
			internal double JerkPowerUp;
			internal double JerkPowerDown;
			internal double JerkBrakeUp;
			internal double JerkBrakeDown;
			/// brake
			internal double BrakeDecelerationAtServiceMaximumPressure;
			internal double BrakeControlSpeed;
			internal double MotorDeceleration;
			/// physical properties
			internal double Mass;
			internal double ExposedFrontalArea;
			internal double UnexposedFrontalArea;
			internal double CoefficientOfStaticFriction;
			internal double CoefficientOfRollingResistance;
			internal double AerodynamicDragCoefficient;
			internal double CenterOfGravityHeight;
			internal double CriticalTopplingAngle;
			/// current data
			internal double CurrentSpeed;
			internal double CurrentPerceivedSpeed;
			internal double CurrentPerceivedTraveledDistance;
			internal double CurrentAcceleration;
			internal double CurrentAccelerationOutput;
			internal double CurrentRollDueToTopplingAngle;
			internal double CurrentRollDueToCantAngle;
			internal double CurrentRollDueToCantAngularSpeed;
			internal double CurrentRollShakeDirection;
			internal double CurrentPitchDueToAccelerationAngle;
			internal double CurrentPitchDueToAccelerationAngularSpeed;
			internal double CurrentPitchDueToAccelerationTargetAngle;
			internal double CurrentPitchDueToAccelerationFastValue;
			internal double CurrentPitchDueToAccelerationMediumValue;
			internal double CurrentPitchDueToAccelerationSlowValue;
			/// systems
			internal CarHoldBrake HoldBrake;
			internal CarConstSpeed ConstSpeed;
			internal CarReAdhesionDevice ReAdhesionDevice;
			internal CarBrakeType BrakeType;
			internal EletropneumaticBrakeType ElectropneumaticType;
			internal CarAirBrake AirBrake;
			/// doors
			internal Door[] Doors;
			internal double DoorOpenFrequency;
			internal double DoorCloseFrequency;
			internal bool AnticipatedLeftDoorsOpened;
			internal bool AnticipatedRightDoorsOpened;
		}
		internal struct CarBrightness {
			internal float PreviousBrightness;
			internal double PreviousTrackPosition;
			internal float NextBrightness;
			internal double NextTrackPosition;
		}
		internal struct Horn {
			internal CarSound Sound;
			internal bool Loop;
		}
		internal struct CarSound {
			internal int SoundBufferIndex;
			internal int SoundSourceIndex;
			internal World.Vector3D Position;
		}
		internal struct MotorSoundTableEntry {
			internal int SoundBufferIndex;
			internal float Pitch;
			internal float Gain;
		}
		internal struct MotorSoundTable {
			internal MotorSoundTableEntry[] Entries;
			internal int SoundBufferIndex;
			internal int SoundSourceIndex;
		}
		internal struct MotorSound {
			internal MotorSoundTable[] Tables;
			internal World.Vector3D Position;
			internal double SpeedConversionFactor;
			internal int CurrentAccelerationDirection;
			internal const int MotorP1 = 0;
			internal const int MotorP2 = 1;
			internal const int MotorB1 = 2;
			internal const int MotorB2 = 3;
		}
		internal struct CarSounds {
			internal MotorSound Motor;
			internal CarSound Adjust;
			internal CarSound Air;
			internal CarSound AirHigh;
			internal CarSound AirZero;
			internal CarSound Ats;
			internal CarSound AtsCnt;
			internal CarSound Brake;
			internal CarSound BrakeHandleApply;
			internal CarSound BrakeHandleRelease;
			internal CarSound BrakeHandleMin;
			internal CarSound BrakeHandleMax;
			internal CarSound CpEnd;
			internal CarSound CpLoop;
			internal bool CpLoopStarted;
			internal CarSound CpStart;
			internal double CpStartTimeStarted;
			internal CarSound Ding;
			internal CarSound DoorCloseL;
			internal CarSound DoorCloseR;
			internal CarSound DoorOpenL;
			internal CarSound DoorOpenR;
			internal CarSound Eb;
			internal CarSound EmrBrake;
			internal CarSound[] Flange;
			internal double[] FlangeVolume;
			internal CarSound Halt;
			internal Horn[] Horns;
			internal CarSound Loop;
			internal CarSound MasterControllerUp;
			internal CarSound MasterControllerDown;
			internal CarSound MasterControllerMin;
			internal CarSound MasterControllerMax;
			internal CarSound PilotLampOn;
			internal CarSound PilotLampOff;
			internal CarSound PointFrontAxle;
			internal CarSound PointRearAxle;
			internal CarSound Rub;
			internal CarSound ReverserOn;
			internal CarSound ReverserOff;
			internal CarSound[] Run;
			internal double[] RunVolume;
			internal CarSound SpringL;
			internal CarSound SpringR;
			internal CarSound ToAtc;
			internal CarSound ToAts;
			internal CarSound[] Plugin;
			internal int FrontAxleRunIndex;
			internal int RearAxleRunIndex;
			internal int FrontAxleFlangeIndex;
			internal int RearAxleFlangeIndex;
			internal double FlangePitch;
			internal double SpringPlayedAngle;
		}
		internal struct Car {
			internal double Width;
			internal double Height;
			internal double Length;
			internal Axle FrontAxle;
			internal Axle RearAxle;
			internal double FrontAxlePosition;
			internal double RearAxlePosition;
			internal World.Vector3D Up;
			internal Section[] Sections;
			internal int CurrentSection;
			internal double DriverX;
			internal double DriverY;
			internal double DriverZ;
			internal double DriverYaw;
			internal double DriverPitch;
			internal CarSpecs Specs;
			internal CarSounds Sounds;
			internal bool CurrentlyVisible;
			internal bool Derailed;
			internal bool Topples;
			internal CarBrightness Brightness;
		}

		// train
		internal struct HandleChange {
			internal int Value;
			internal double Time;
		}
		internal struct PowerHandle {
			internal int Driver;
			internal int Security;
			internal int Actual;
			internal HandleChange[] DelayedChanges;
			internal void AddChange(Train Train, int Value, double Delay) {
				int n = DelayedChanges.Length;
				Array.Resize<HandleChange>(ref DelayedChanges, n + 1);
				DelayedChanges[n].Value = Value;
				DelayedChanges[n].Time = Game.SecondsSinceMidnight + Delay;
			}
			internal void RemoveChanges(int Count) {
				int n = DelayedChanges.Length;
				for (int i = 0; i < n - Count; i++) {
					DelayedChanges[i] = DelayedChanges[i + Count];
				}
				Array.Resize<HandleChange>(ref DelayedChanges, n - Count);
			}
		}
		internal struct BrakeHandle {
			internal int Driver;
			internal int Security;
			internal int Actual;
			internal HandleChange[] DelayedChanges;
			internal void AddChange(Train Train, int Value, double Delay) {
				int n = DelayedChanges.Length;
				Array.Resize<HandleChange>(ref DelayedChanges, n + 1);
				DelayedChanges[n].Value = Value;
				DelayedChanges[n].Time = Game.SecondsSinceMidnight + Delay;
			}
			internal void RemoveChanges(int Count) {
				int n = DelayedChanges.Length;
				for (int i = 0; i < n - Count; i++) {
					DelayedChanges[i] = DelayedChanges[i + Count];
				}
				Array.Resize<HandleChange>(ref DelayedChanges, n - Count);
			}
		}
		internal struct EmergencyHandle {
			internal bool Driver;
			internal bool Security;
			internal bool Actual;
			internal double ApplicationTime;
		}
		internal struct ReverserHandle {
			internal int Driver;
			internal int Actual;
		}
		internal struct HoldBrakeHandle {
			internal bool Driver;
			internal bool Actual;
		}
		// train security
		internal enum SecurityState {
			Normal = 0,
			Initialization = 1,
			Ringing = 2,
			Emergency = 3,
			Pattern = 4,
			Service = 5
		}
		internal enum SecuritySystem {
			Bve4Plugin = -1,
			None = 0,
			AtsSN = 1,
			AtsP = 2,
			Atc = 3
		}
		internal struct Ats {
			internal double Time;
			internal bool AtsAvailable;
			internal bool AtsPAvailable;
			internal double AtsPDistance;
			internal double AtsPTemporarySpeed;
			internal double AtsPPermanentSpeed;
			internal bool AtsPOverride;
			internal double AtsPOverrideTime;
		}
		internal struct Atc {
			internal bool Available;
			internal bool Transmitting;
			internal bool AutomaticSwitch;
			internal double SpeedRestriction;
		}
		internal struct Eb {
			internal bool Available;
			internal SecurityState BellState;
			internal double Time;
			internal bool Reset;
		}
		internal struct TrainPendingTransponder {
			internal TrackManager.TransponderType Type;
			internal bool SwitchSubsystem;
			internal int OptionalInteger;
			internal double OptionalFloat;
			internal int SectionIndex;
		}
		internal struct TrainSecurity {
			internal SecuritySystem Mode;
			internal SecuritySystem ModeChange;
			internal SecurityState State;
			internal TrainPendingTransponder[] PendingTransponders;
			internal Ats Ats;
			internal Atc Atc;
			internal Eb Eb;
			internal void AddPendingTransponder(TrainPendingTransponder Data) {
				int n = this.PendingTransponders.Length;
				Array.Resize<TrainPendingTransponder>(ref this.PendingTransponders, n + 1);
				this.PendingTransponders[n] = Data;
			}
			internal bool IsTransponderPending() {
				return this.PendingTransponders.Length > 0;
			}
			internal TrainPendingTransponder GetPendingTransponder() {
				if (this.PendingTransponders.Length != 0) {
					return this.PendingTransponders[0];
				} else {
					TrainPendingTransponder Data;
					Data.Type = TrackManager.TransponderType.None;
					Data.SwitchSubsystem = false;
					Data.OptionalInteger = 0;
					Data.OptionalFloat = 0;
					Data.SectionIndex = 0;
					return Data;
				}
			}
			internal void RemovePendingTransponder() {
				int n = this.PendingTransponders.Length;
				if (n != 0) {
					for (int i = 0; i < n - 1; i++) {
						this.PendingTransponders[i] = this.PendingTransponders[i + 1];
					} Array.Resize<TrainPendingTransponder>(ref this.PendingTransponders, n - 1);
				}
			}
		}
		// train specs
		internal enum PassAlarmType {
			None = 0,
			Single = 1,
			Loop = 2
		}
		internal struct TrainAirBrake {
			internal AirBrakeHandle Handle;
		}
		internal enum DoorMode {
			AutomaticManualOverride = 0,
			Automatic = 1,
			Manual = 2
		}
		internal struct TrainSpecs {
			internal double TotalMass;
			internal ReverserHandle CurrentReverser;
			internal double CurrentAverageSpeed;
			internal double CurrentAverageAcceleration;
			internal double CurrentAverageJerk;
			internal double CurrentAirPressure;
			internal double CurrentAirDensity;
			internal double CurrentAirTemperature;
			internal double CurrentElevation;
			internal bool SingleHandle;
			internal int PowerNotchReduceSteps;
			internal int MaximumPowerNotch;
			internal PowerHandle CurrentPowerNotch;
			internal int MaximumBrakeNotch;
			internal BrakeHandle CurrentBrakeNotch;
			internal EmergencyHandle CurrentEmergencyBrake;
			internal bool HasHoldBrake;
			internal HoldBrakeHandle CurrentHoldBrake;
			internal bool HasConstSpeed;
			internal bool CurrentConstSpeed;
			internal TrainSecurity Security;
			internal TrainAirBrake AirBrake;
			internal double DelayPowerUp;
			internal double DelayPowerDown;
			internal double DelayBrakeUp;
			internal double DelayBrakeDown;
			internal PassAlarmType PassAlarm;
			internal DoorMode DoorOpenMode;
			internal DoorMode DoorCloseMode;
		}
		// passengers
		internal struct TrainPassengers {
			internal double PassengerRatio;
			internal double CurrentAcceleration;
			internal double CurrentSpeedDifference;
			internal bool FallenOver;
		}
		// train
		internal enum TrainStopState {
			Pending = 0, Boarding = 1, Completed = 2
		}
		internal class Train {
			internal int TrainIndex;
			internal bool Disposed;
			internal bool IsBogusTrain;
			internal Car[] Cars;
			internal Coupler[] Couplers;
			internal int DriverCar;
			internal TrainSpecs Specs;
			internal TrainPassengers Passengers;
			internal int Station;
			internal bool StationFrontCar;
			internal bool StationRearCar;
			internal TrainStopState StationState;
			internal double StationArrivalTime;
			internal double StationDepartureTime;
			internal bool StationDepartureSoundPlayed;
			internal bool StationAdjust;
			internal double StationDistanceToStopPoint;
			internal double[] RouteLimits;
			internal double CurrentRouteLimit;
			internal double CurrentSectionLimit;
			internal int CurrentSectionIndex;
			internal double PretrainAheadTimetable;
			internal Game.GeneralAI AI;
			internal double InternalTimerTimeElapsed;
		}

		// trains
		/// <summary>The list of trains available in the simulation.</summary>
		internal static Train[] Trains = null;
		/// <summary>A reference to the train of the Trains element that corresponds to the player's train.</summary>
		internal static Train PlayerTrain = null;

		// ================================

		// parse panel config
		internal static void ParsePanelConfig(string TrainPath, System.Text.Encoding Encoding, TrainManager.Train Train, bool OverlayMode) {
			string File = Interface.GetCombinedFileName(TrainPath, "panel2.cfg");
			if (System.IO.File.Exists(File)) {
				Panel2CfgParser.ParsePanel2Config(TrainPath, Encoding, Train);
			} else {
				PanelCfgParser.ParsePanelConfig(TrainPath, Encoding, Train);
			}
		}

		// ================================

		// move car
		internal static void MoveCar(Train Train, int CarIndex, double Delta, double TimeElapsed) {
			TrackManager.UpdateTrackFollower(ref Train.Cars[CarIndex].FrontAxle.Follower, Train.Cars[CarIndex].FrontAxle.Follower.TrackPosition + Delta, true, true);
			TrackManager.UpdateTrackFollower(ref Train.Cars[CarIndex].RearAxle.Follower, Train.Cars[CarIndex].RearAxle.Follower.TrackPosition + Delta, true, true);
			if (!Train.IsBogusTrain) {
				UpdateTopplingCantAndSpring(Train, CarIndex, TimeElapsed);
			}
		}

		// update atmospheric constants
		internal static void UpdateAtmosphericConstants(Train Train) {
			double h = 0.0;
			for (int i = 0; i < Train.Cars.Length; i++) {
				h += Train.Cars[i].FrontAxle.Follower.WorldPosition.Y + Train.Cars[i].RearAxle.Follower.WorldPosition.Y;
			}
			Train.Specs.CurrentElevation = Game.RouteInitialElevation + h / (2.0 * (double)Train.Cars.Length);
			Train.Specs.CurrentAirTemperature = Game.GetAirTemperature(Train.Specs.CurrentElevation);
			Train.Specs.CurrentAirPressure = Game.GetAirPressure(Train.Specs.CurrentElevation, Train.Specs.CurrentAirTemperature);
			Train.Specs.CurrentAirDensity = Game.GetAirDensity(Train.Specs.CurrentAirPressure, Train.Specs.CurrentAirTemperature);
		}

		// get acceleration
		internal static double GetAcceleration(Train Train, int CarIndex, int CurveIndex, double Speed) {
			if (CurveIndex < Train.Cars[CarIndex].Specs.AccelerationCurves.Length) {
				if (Speed < 0.0) Speed = 0.0;
				double a0 = Train.Cars[CarIndex].Specs.AccelerationCurves[CurveIndex].StageZeroAcceleration;
				double s1 = Train.Cars[CarIndex].Specs.AccelerationCurves[CurveIndex].StageOneSpeed;
				double a1 = Train.Cars[CarIndex].Specs.AccelerationCurves[CurveIndex].StageOneAcceleration;
				double s2 = Train.Cars[CarIndex].Specs.AccelerationCurves[CurveIndex].StageTwoSpeed;
				double e2 = Train.Cars[CarIndex].Specs.AccelerationCurves[CurveIndex].StageTwoExponent;
				double f = Train.Cars[CarIndex].Specs.AccelerationCurvesMultiplier;
				if (Speed == 0.0) {
					return a0;
				} else if (Speed < s1) {
					double t = Speed / s1;
					return f * (a0 * (1.0 - t) + a1 * t);
				} else if (Speed < s2) {
					return f * s1 * a1 / Speed;
				} else {
					return f * s1 * a1 * Math.Pow(s2, e2 - 1.0) * Math.Pow(Speed, -e2);
				}
			} else {
				return 0.0;
			}
		}

		// get resistance
		private static double GetResistance(Train Train, int CarIndex, ref Axle Axle, double Speed) {
			double t;
			if (CarIndex == 0 & Train.Cars[CarIndex].Specs.CurrentSpeed >= 0.0 || CarIndex == Train.Cars.Length - 1 & Train.Cars[CarIndex].Specs.CurrentSpeed <= 0.0) {
				t = Train.Cars[CarIndex].Specs.ExposedFrontalArea;
			} else {
				t = Train.Cars[CarIndex].Specs.UnexposedFrontalArea;
			}
			double f = t * Train.Cars[CarIndex].Specs.AerodynamicDragCoefficient * Train.Specs.CurrentAirDensity / (2.0 * Train.Cars[CarIndex].Specs.Mass);
			double a = Game.RouteAccelerationDueToGravity * Train.Cars[CarIndex].Specs.CoefficientOfRollingResistance + f * Speed * Speed;
			return a;
		}

		// get critical wheelslip acceleration
		private static double GetCriticalWheelSlipAcceleration(Train Train, int CarIndex, double AdhesionMultiplier, double UpY) {
			double NormalForceAcceleration = UpY * Game.RouteAccelerationDueToGravity;
			return Train.Cars[CarIndex].Specs.CoefficientOfStaticFriction * AdhesionMultiplier * NormalForceAcceleration;
		}

		// update toppling, cant and spring
		internal static void UpdateTopplingCantAndSpring(Train Train, int CarIndex, double TimeElapsed) {
			// get direction, up and side vectors
			double dx, dy, dz;
			double ux, uy, uz;
			double sx, sy, sz;
			{
				dx = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X;
				dy = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y;
				dz = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z;
				double t = 1.0 / Math.Sqrt(dx * dx + dy * dy + dz * dz);
				dx *= t; dy *= t; dz *= t;
				t = 1.0 / Math.Sqrt(dx * dx + dz * dz);
				double ex = dx * t;
				double ez = dz * t;
				sx = ez;
				sy = 0.0;
				sz = -ex;
				World.Cross(dx, dy, dz, sx, sy, sz, out ux, out uy, out uz);
			}
			// cant and radius
			double c;
			if (!Train.Cars[CarIndex].Derailed) {
				c = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.CurveCant + Train.Cars[CarIndex].RearAxle.Follower.CurveCant);
			} else {
				c = 0.0;
			}
			double r, rs;
			if (Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius != 0.0 & Train.Cars[CarIndex].RearAxle.Follower.CurveRadius != 0.0) {
				r = Math.Sqrt(Math.Abs(Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius * Train.Cars[CarIndex].RearAxle.Follower.CurveRadius));
				rs = (double)Math.Sign(Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius + Train.Cars[CarIndex].RearAxle.Follower.CurveRadius);
			} else if (Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius != 0.0) {
				r = Math.Abs(Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius);
				rs = (double)Math.Sign(Train.Cars[CarIndex].FrontAxle.Follower.CurveRadius);
			} else if (Train.Cars[CarIndex].RearAxle.Follower.CurveRadius != 0.0) {
				r = Math.Abs(Train.Cars[CarIndex].RearAxle.Follower.CurveRadius);
				rs = (double)Math.Sign(Train.Cars[CarIndex].RearAxle.Follower.CurveRadius);
			} else {
				r = 0.0;
				rs = 0.0;
			}
			// roll due to toppling/cant/shaking
			{
				double a0 = Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle;
				double a1 = Math.Atan(c / Game.RouteRailGauge);
				if (Train.Cars[CarIndex].Specs.CurrentRollShakeDirection != 0.0) {
					const double c0 = 0.03;
					const double c1 = 0.15;
					a1 += c1 * Math.Atan(c0 * Train.Cars[CarIndex].Specs.CurrentRollShakeDirection);
					double d = 0.5 + Train.Cars[CarIndex].Specs.CurrentRollShakeDirection * Train.Cars[CarIndex].Specs.CurrentRollShakeDirection;
					if (Train.Cars[CarIndex].Specs.CurrentRollShakeDirection < 0.0) {
						Train.Cars[CarIndex].Specs.CurrentRollShakeDirection += d * TimeElapsed;
						if (Train.Cars[CarIndex].Specs.CurrentRollShakeDirection > 0.0) Train.Cars[CarIndex].Specs.CurrentRollShakeDirection = 0.0;
					} else {
						Train.Cars[CarIndex].Specs.CurrentRollShakeDirection -= d * TimeElapsed;
						if (Train.Cars[CarIndex].Specs.CurrentRollShakeDirection < 0.0) Train.Cars[CarIndex].Specs.CurrentRollShakeDirection = 0.0;
					}
				}
				double SpringAcceleration;
				if (!Train.Cars[CarIndex].Derailed) {
					SpringAcceleration = 15.0 * Math.Abs(a1 - a0);
				} else {
					SpringAcceleration = 1.0 * Math.Abs(a1 - a0);
				}
				double SpringDeceleration = 0.5 * SpringAcceleration;
				Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed += (double)Math.Sign(a1 - a0) * SpringAcceleration * TimeElapsed;
				double x = (double)Math.Sign(Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed) * SpringDeceleration * TimeElapsed;
				if (Math.Abs(x) < Math.Abs(Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed)) {
					Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed -= x;
				} else {
					Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed = 0.0;
				}
				a0 += Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngularSpeed * TimeElapsed;
				Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle = a0;
			}
			// pitch due to acceleration
			{
				for (int i = 0; i < 3; i++) {
					double a, v, j;
					if (i == 0) {
						a = Train.Cars[CarIndex].Specs.CurrentAcceleration;
						v = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationFastValue;
						j = 1.8;
					} else if (i == 1) {
						a = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationFastValue;
						v = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationMediumValue;
						j = 1.2;
					} else {
						a = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationFastValue;
						v = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationSlowValue;
						j = 1.0;
					}
					double d = a - v;
					if (d < 0.0) {
						v -= j * TimeElapsed;
						if (v < a) v = a;
					} else {
						v += j * TimeElapsed;
						if (v > a) v = a;
					}
					if (i == 0) {
						Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationFastValue = v;
					} else if (i == 1) {
						Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationMediumValue = v;
					} else {
						Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationSlowValue = v;
					}
				}
				{
					double d = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationSlowValue - Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationFastValue;
					Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationTargetAngle = 0.03 * Math.Atan(d);
				}
				{
					double a = 3.0 * (double)Math.Sign(Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationTargetAngle - Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngle);
					Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngularSpeed += a * TimeElapsed;
					double s = Math.Abs(Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationTargetAngle - Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngle);
					if (Math.Abs(Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngularSpeed) > s) {
						Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngularSpeed = s * (double)Math.Sign(Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngularSpeed);
					}
					Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngle += Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngularSpeed * TimeElapsed;
				}
			}
			// derailment
			if (Interface.CurrentOptions.Derailments & !Train.Cars[CarIndex].Derailed) {
				double a = Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle + Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle;
				double sa = (double)Math.Sign(a);
				double tc = Train.Cars[CarIndex].Specs.CriticalTopplingAngle;
				if (a * sa > tc) {
					Train.Cars[CarIndex].Derailed = true;
				}
			}
			// toppling roll and positions
			if (Interface.CurrentOptions.Toppling | Train.Cars[CarIndex].Derailed) {
				double a = Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle;
				double ab = Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle + Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle;
				double sa = (double)Math.Sign(a);
				double gh = 0.5 * Game.RouteRailGauge;
				double x = (sa - sa * Math.Cos(a)) * gh;
				double y = gh * Math.Sin(Math.Abs(a));
				double h = Train.Cars[CarIndex].Specs.CenterOfGravityHeight;
				double s = Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed);
				double rmax = 2.0 * h * s * s / (Game.RouteAccelerationDueToGravity * Game.RouteRailGauge);
				double ta;
				Train.Cars[CarIndex].Topples = false;
				if (Train.Cars[CarIndex].Derailed) {
					double sab = (double)Math.Sign(ab);
					ta = 0.5 * Math.PI * (sab == 0.0 ? Game.Generator.NextDouble() < 0.5 ? -1.0 : 1.0 : sab);
				} else {
					if (r != 0.0) {
						if (r < rmax) {
							double s0 = Math.Sqrt(r * Game.RouteAccelerationDueToGravity * Game.RouteRailGauge / (2.0 * h));
							const double fac = 0.25; /// arbitrary coefficient
							ta = -fac * (s - s0) * rs;
							Train.Cars[CarIndex].Topples = true;
						} else {
							ta = 0.0;
						}
					} else {
						ta = 0.0;
					}
				}
				double td;
				if (Train.Cars[CarIndex].Derailed) {
					td = Math.Abs(ab);
					if (td < 0.1) td = 0.1;
				} else {
					td = 1.0;
				}
				if (a > ta) {
					double d = a - ta;
					if (td > d) td = d;
					a -= td * TimeElapsed;
				} else if (a < ta) {
					double d = ta - a;
					if (td > d) td = d;
					a += td * TimeElapsed;
				}
				double cx = sx * x + ux * y;
				double cy = sy * x + uy * y;
				double cz = sz * x + uz * y;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X += cx;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y += cy;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z += cz;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X += cx;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y += cy;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z += cz;
				Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle = a;
			} else {
				Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle = 0.0;
			}
			// apply rolling
			{
				double a = -Train.Cars[CarIndex].Specs.CurrentRollDueToTopplingAngle - Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle;
				double cosa = Math.Cos(a);
				double sina = Math.Sin(a);
				World.Rotate(ref sx, ref sy, ref sz, dx, dy, dz, cosa, sina);
				World.Rotate(ref ux, ref uy, ref uz, dx, dy, dz, cosa, sina);
				Train.Cars[CarIndex].Up.X = ux;
				Train.Cars[CarIndex].Up.Y = uy;
				Train.Cars[CarIndex].Up.Z = uz;
			}
			// apply pitching
			if (Train.Cars[CarIndex].CurrentSection >= 0 && Train.Cars[CarIndex].Sections[Train.Cars[CarIndex].CurrentSection].Overlay) {
				double a = Train.Cars[CarIndex].Specs.CurrentPitchDueToAccelerationAngle;
				double cosa = Math.Cos(a);
				double sina = Math.Sin(a);
				World.Rotate(ref dx, ref dy, ref dz, sx, sy, sz, cosa, sina);
				World.Rotate(ref ux, ref uy, ref uz, sx, sy, sz, cosa, sina);
				double cx = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X);
				double cy = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y);
				double cz = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z);
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X -= cx;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y -= cy;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z -= cz;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X -= cx;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y -= cy;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z -= cz;
				World.Rotate(ref Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X, ref Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y, ref Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z, sx, sy, sz, cosa, sina);
				World.Rotate(ref Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X, ref Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y, ref Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z, sx, sy, sz, cosa, sina);
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X += cx;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y += cy;
				Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z += cz;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X += cx;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y += cy;
				Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z += cz;
				Train.Cars[CarIndex].Up.X = ux;
				Train.Cars[CarIndex].Up.Y = uy;
				Train.Cars[CarIndex].Up.Z = uz;
			}
			// spring sound
			{
				double a = Train.Cars[CarIndex].Specs.CurrentRollDueToCantAngle;
				double diff = a - Train.Cars[CarIndex].Sounds.SpringPlayedAngle;
				if (diff < -0.0275) {
					int snd = Train.Cars[CarIndex].Sounds.SpringL.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[CarIndex].Sounds.SpringL.Position;
						SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
					}
					Train.Cars[CarIndex].Sounds.SpringPlayedAngle = a;
				} else if (diff > 0.0275) {
					int snd = Train.Cars[CarIndex].Sounds.SpringR.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[CarIndex].Sounds.SpringR.Position;
						SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
					}
					Train.Cars[CarIndex].Sounds.SpringPlayedAngle = a;
				}
			}
			// flange sound
			{
				World.Vector3D d = World.Vector3D.Subtract(Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition, Train.Cars[CarIndex].RearAxle.Follower.WorldPosition);
				World.Normalize(ref d.X, ref d.Y, ref d.Z);
				double b0 = d.X * Train.Cars[CarIndex].RearAxle.Follower.WorldSide.X + d.Y * Train.Cars[CarIndex].RearAxle.Follower.WorldSide.Y + d.Z * Train.Cars[CarIndex].RearAxle.Follower.WorldSide.Z;
				double b1 = d.X * Train.Cars[CarIndex].FrontAxle.Follower.WorldSide.X + d.Y * Train.Cars[CarIndex].FrontAxle.Follower.WorldSide.Y + d.Z * Train.Cars[CarIndex].FrontAxle.Follower.WorldSide.Z;
				double spd = Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed);
				double pitch = 0.5 + 0.04 * spd;
				double b2 = Math.Abs(b0) + Math.Abs(b1);
				double basegain = b2 * spd;
				if (basegain < 0.0) basegain = 0.0;
				if (basegain > 0.75) basegain = 0.75;
				if (pitch > Train.Cars[CarIndex].Sounds.FlangePitch) {
					Train.Cars[CarIndex].Sounds.FlangePitch += TimeElapsed;
					if (Train.Cars[CarIndex].Sounds.FlangePitch > pitch) Train.Cars[CarIndex].Sounds.FlangePitch = pitch;
				} else {
					Train.Cars[CarIndex].Sounds.FlangePitch -= TimeElapsed;
					if (Train.Cars[CarIndex].Sounds.FlangePitch < pitch) Train.Cars[CarIndex].Sounds.FlangePitch = pitch;
				}
				pitch = Train.Cars[CarIndex].Sounds.FlangePitch;
				for (int i = 0; i < Train.Cars[CarIndex].Sounds.Flange.Length; i++) {
					if (i == Train.Cars[CarIndex].Sounds.FrontAxleFlangeIndex | i == Train.Cars[CarIndex].Sounds.RearAxleFlangeIndex) {
						Train.Cars[CarIndex].Sounds.FlangeVolume[i] += TimeElapsed;
						if (Train.Cars[CarIndex].Sounds.FlangeVolume[i] > 1.0) Train.Cars[CarIndex].Sounds.FlangeVolume[i] = 1.0;
					} else {
						Train.Cars[CarIndex].Sounds.FlangeVolume[i] -= TimeElapsed;
						if (Train.Cars[CarIndex].Sounds.FlangeVolume[i] < 0.0) Train.Cars[CarIndex].Sounds.FlangeVolume[i] = 0.0;
					}
					double gain = basegain * Train.Cars[CarIndex].Sounds.FlangeVolume[i];
					if (Train.Cars[CarIndex].Sounds.Flange[i].SoundSourceIndex >= 0) {
						if (pitch > 0.01 & gain > 0.0001) {
							SoundManager.ModulateSound(Train.Cars[CarIndex].Sounds.Flange[i].SoundSourceIndex, pitch, gain);
						} else {
							SoundManager.StopSound(ref Train.Cars[CarIndex].Sounds.Flange[i].SoundSourceIndex);
						}
					} else if (pitch > 0.02 & gain > 0.01) {
						int snd = Train.Cars[CarIndex].Sounds.Flange[i].SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[CarIndex].Sounds.Flange[i].Position;
							SoundManager.PlaySound(ref Train.Cars[CarIndex].Sounds.Flange[i].SoundSourceIndex, snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, true, pitch, gain);
						}
					}
				}
			}
		}

		// update camera
		internal static void UpdateCamera(Train Train) {
			int i = Train.DriverCar;
			double dx = Train.Cars[i].FrontAxle.Follower.WorldPosition.X - Train.Cars[i].RearAxle.Follower.WorldPosition.X;
			double dy = Train.Cars[i].FrontAxle.Follower.WorldPosition.Y - Train.Cars[i].RearAxle.Follower.WorldPosition.Y;
			double dz = Train.Cars[i].FrontAxle.Follower.WorldPosition.Z - Train.Cars[i].RearAxle.Follower.WorldPosition.Z;
			double t = 1.0 / Math.Sqrt(dx * dx + dy * dy + dz * dz);
			dx *= t; dy *= t; dz *= t;
			double ux = Train.Cars[i].Up.X;
			double uy = Train.Cars[i].Up.Y;
			double uz = Train.Cars[i].Up.Z;
			double sx = dz * uy - dy * uz;
			double sy = dx * uz - dz * ux;
			double sz = dy * ux - dx * uy;
			double rx = 0.5 * (Train.Cars[i].FrontAxle.Follower.WorldPosition.X + Train.Cars[i].RearAxle.Follower.WorldPosition.X);
			double ry = 0.5 * (Train.Cars[i].FrontAxle.Follower.WorldPosition.Y + Train.Cars[i].RearAxle.Follower.WorldPosition.Y);
			double rz = 0.5 * (Train.Cars[i].FrontAxle.Follower.WorldPosition.Z + Train.Cars[i].RearAxle.Follower.WorldPosition.Z);
			double cx = rx + sx * Train.Cars[i].DriverX + ux * Train.Cars[i].DriverY + dx * Train.Cars[i].DriverZ;
			double cy = ry + sy * Train.Cars[i].DriverX + uy * Train.Cars[i].DriverY + dy * Train.Cars[i].DriverZ;
			double cz = rz + sz * Train.Cars[i].DriverX + uz * Train.Cars[i].DriverY + dz * Train.Cars[i].DriverZ;
			World.CameraTrackFollower.WorldPosition = new World.Vector3D(cx, cy, cz);
			World.CameraTrackFollower.WorldDirection = new World.Vector3D(dx, dy, dz);
			World.CameraTrackFollower.WorldUp = new World.Vector3D(ux, uy, uz);
			World.CameraTrackFollower.WorldSide = new World.Vector3D(sx, sy, sz);
			double f = (Train.Cars[i].DriverZ - Train.Cars[i].RearAxlePosition) / (Train.Cars[i].FrontAxlePosition - Train.Cars[i].RearAxlePosition);
			double tp = (1.0 - f) * Train.Cars[i].RearAxle.Follower.TrackPosition + f * Train.Cars[i].FrontAxle.Follower.TrackPosition;
			TrackManager.UpdateTrackFollower(ref World.CameraTrackFollower, tp, false, false);
		}

		// create world coordinates
		internal static void CreateWorldCoordinates(Train Train, int CarIndex, double CarX, double CarY, double CarZ, out double PositionX, out double PositionY, out double PositionZ, out double DirectionX, out double DirectionY, out double DirectionZ) {
			DirectionX = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X;
			DirectionY = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y;
			DirectionZ = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z - Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z;
			double t = DirectionX * DirectionX + DirectionY * DirectionY + DirectionZ * DirectionZ;
			if (t != 0.0) {
				t = 1.0 / Math.Sqrt(t);
				DirectionX *= t; DirectionY *= t; DirectionZ *= t;
				double ux = Train.Cars[CarIndex].Up.X;
				double uy = Train.Cars[CarIndex].Up.Y;
				double uz = Train.Cars[CarIndex].Up.Z;
				double sx = DirectionZ * uy - DirectionY * uz;
				double sy = DirectionX * uz - DirectionZ * ux;
				double sz = DirectionY * ux - DirectionX * uy;
				double rx = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.X);
				double ry = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Y);
				double rz = 0.5 * (Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z + Train.Cars[CarIndex].RearAxle.Follower.WorldPosition.Z);
				PositionX = rx + sx * CarX + ux * CarY + DirectionX * CarZ;
				PositionY = ry + sy * CarX + uy * CarY + DirectionY * CarZ;
				PositionZ = rz + sz * CarX + uz * CarY + DirectionZ * CarZ;
			} else {
				PositionX = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.X;
				PositionY = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Y;
				PositionZ = Train.Cars[CarIndex].FrontAxle.Follower.WorldPosition.Z;
				DirectionX = 0.0;
				DirectionY = 1.0;
				DirectionZ = 0.0;
			}
		}

		// initialize train
		internal static void InitializeTrain(Train Train) {
			for (int i = 0; i < Train.Cars.Length; i++) {
				InitializeCar(Train, i);
			}
			UpdateAtmosphericConstants(Train);
			UpdateTrain(Train, 0.0);
		}

		// initialize car
		private static void InitializeCar(Train Train, int CarIndex) {
			int c = CarIndex;
			for (int i = 0; i < Train.Cars[c].Sections.Length; i++) {
				InitializeCarSection(Train, c, i);
			}
			Train.Cars[c].Brightness.PreviousBrightness = 1.0f;
			Train.Cars[c].Brightness.NextBrightness = 1.0f;
		}

		// initialize car section
		internal static void InitializeCarSection(Train Train, int CarIndex, int SectionIndex) {
			int c = CarIndex;
			int s = SectionIndex;
			for (int j = 0; j < Train.Cars[c].Sections[s].Elements.Length; j++) {
				for (int k = 0; k < Train.Cars[c].Sections[s].Elements[j].States.Length; k++) {
					InitializeCarSectionElement(Train, c, s, j, k);
				}
			}
		}

		// initialize car section element
		internal static void InitializeCarSectionElement(Train Train, int CarIndex, int SectionIndex, int ElementIndex, int StateIndex) {
			ObjectManager.InitializeAnimatedObject(ref Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex], StateIndex, Train.Cars[CarIndex].Sections[SectionIndex].Overlay);
		}

		// update car
		private static void UpdateCar(Train Train, int CarIndex, double TimeElapsed) {
			// calculate positions and directions for section element update
			int c = CarIndex;
			double dx = Train.Cars[c].FrontAxle.Follower.WorldPosition.X - Train.Cars[c].RearAxle.Follower.WorldPosition.X;
			double dy = Train.Cars[c].FrontAxle.Follower.WorldPosition.Y - Train.Cars[c].RearAxle.Follower.WorldPosition.Y;
			double dz = Train.Cars[c].FrontAxle.Follower.WorldPosition.Z - Train.Cars[c].RearAxle.Follower.WorldPosition.Z;
			double t = dx * dx + dy * dy + dz * dz;
			double ux, uy, uz, sx, sy, sz;
			if (t != 0.0) {
				t = 1.0 / Math.Sqrt(t);
				dx *= t; dy *= t; dz *= t;
				ux = Train.Cars[c].Up.X;
				uy = Train.Cars[c].Up.Y;
				uz = Train.Cars[c].Up.Z;
				sx = dz * uy - dy * uz;
				sy = dx * uz - dz * ux;
				sz = dy * ux - dx * uy;
			} else {
				ux = 0.0; uy = 1.0; uz = 0.0;
				sx = 1.0; sy = 0.0; sz = 0.0;
			}
			double px = 0.5 * (Train.Cars[c].FrontAxle.Follower.WorldPosition.X + Train.Cars[c].RearAxle.Follower.WorldPosition.X);
			double py = 0.5 * (Train.Cars[c].FrontAxle.Follower.WorldPosition.Y + Train.Cars[c].RearAxle.Follower.WorldPosition.Y);
			double pz = 0.5 * (Train.Cars[c].FrontAxle.Follower.WorldPosition.Z + Train.Cars[c].RearAxle.Follower.WorldPosition.Z);
			// determine visibility
			bool v = Train.Cars[c].CurrentlyVisible;
			bool vc = false;
			double cdx = px - World.AbsoluteCameraPosition.X;
			double cdy = py - World.AbsoluteCameraPosition.Y;
			double cdz = pz - World.AbsoluteCameraPosition.Z;
			double dist = cdx * cdx + cdy * cdy + cdz * cdz;
			double bid = World.BackgroundImageDistance + Train.Cars[c].Length;
			if (dist < bid * bid) {
				if (!v) vc = true;
				v = true;
			} else {
				if (v) vc = true;
				v = false;
			}
			Train.Cars[c].CurrentlyVisible = v;
			// brightness
			byte dnb;
			{
				float Brightness = (float)(Train.Cars[c].Brightness.NextTrackPosition - Train.Cars[c].Brightness.PreviousTrackPosition);
				if (Brightness != 0.0f) {
					Brightness = (float)(Train.Cars[c].FrontAxle.Follower.TrackPosition - Train.Cars[c].Brightness.PreviousTrackPosition) / Brightness;
					if (Brightness < 0.0f) Brightness = 0.0f;
					if (Brightness > 1.0f) Brightness = 1.0f;
					Brightness = Train.Cars[c].Brightness.PreviousBrightness * (1.0f - Brightness) + Train.Cars[c].Brightness.NextBrightness * Brightness;
				} else {
					Brightness = Train.Cars[c].Brightness.PreviousBrightness;
				}
				dnb = (byte)Math.Round(255.0 * (double)(1.0 - Brightness));
			}
			// update current section
			int s = Train.Cars[c].CurrentSection;
			if (s >= 0) {
				if (World.CameraMode == World.CameraViewMode.Interior & Train.Cars[c].Sections[s].Overlay) {
					UpdateCamera(Train);
					World.UpdateAbsoluteCamera(TimeElapsed);
				}
				for (int i = 0; i < Train.Cars[c].Sections[s].Elements.Length; i++) {
					ObjectManager.VisibilityChangeMode Visibility = vc ? v ? ObjectManager.VisibilityChangeMode.Show : ObjectManager.VisibilityChangeMode.Hide : ObjectManager.VisibilityChangeMode.DontChange;
					UpdateCarSectionElement(Train, CarIndex, s, i, new World.Vector3D(px, py, pz), new World.Vector3D(dx, dy, dz), new World.Vector3D(ux, uy, uz), new World.Vector3D(sx, sy, sz), Visibility, TimeElapsed);
					// brightness change
					int o = Train.Cars[c].Sections[s].Elements[i].ObjectIndex;
					if (ObjectManager.Objects[o] != null) {
						for (int j = 0; j < ObjectManager.Objects[o].Mesh.Materials.Length; j++) {
							ObjectManager.Objects[o].Mesh.Materials[j].DaytimeNighttimeBlend = dnb;
						}
					}
				}
			}
		}

		// change car section
		internal static void ChangeCarSection(Train Train, int CarIndex, int SectionIndex) {
			for (int i = 0; i < Train.Cars[CarIndex].Sections.Length; i++) {
				for (int j = 0; j < Train.Cars[CarIndex].Sections[i].Elements.Length; j++) {
					int o = Train.Cars[CarIndex].Sections[i].Elements[j].ObjectIndex;
					Renderer.HideObject(o);
				}
			}
			if (SectionIndex >= 0) {
				InitializeCarSection(Train, CarIndex, SectionIndex);
				for (int j = 0; j < Train.Cars[CarIndex].Sections[SectionIndex].Elements.Length; j++) {
					int o = Train.Cars[CarIndex].Sections[SectionIndex].Elements[j].ObjectIndex;
					Renderer.ShowObject(o, Train.Cars[CarIndex].Sections[SectionIndex].Overlay);
				}
			}
			Train.Cars[CarIndex].CurrentSection = SectionIndex;
		}

		// update car section element
		private static void UpdateCarSectionElement(Train Train, int CarIndex, int SectionIndex, int ElementIndex, World.Vector3D Position, World.Vector3D Direction, World.Vector3D Up, World.Vector3D Side, ObjectManager.VisibilityChangeMode Visibility, double TimeElapsed) {
			World.Vector3D p;
			if (Train.Cars[CarIndex].Sections[SectionIndex].Overlay) {
				p = new World.Vector3D(Train.Cars[CarIndex].DriverX, Train.Cars[CarIndex].DriverY, Train.Cars[CarIndex].DriverZ);
			} else {
				p = Position;
			}
			bool updatefunctions;
			if (Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex].RefreshRate != 0.0) {
				if (Game.SecondsSinceMidnight >= Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex].TimeNextUpdating) {
					Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex].TimeNextUpdating = Game.SecondsSinceMidnight + Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex].RefreshRate;
					updatefunctions = true;
				} else {
					updatefunctions = false;
				}
			} else {
				updatefunctions = true;
			}
			ObjectManager.UpdateAnimatedObject(ref Train.Cars[CarIndex].Sections[SectionIndex].Elements[ElementIndex], Train, Train.Cars[CarIndex].CurrentSection, Train.Cars[CarIndex].FrontAxle.Follower.TrackPosition - Train.Cars[CarIndex].FrontAxlePosition, p, Direction, Up, Side, Train.Cars[CarIndex].Sections[SectionIndex].Overlay, updatefunctions, Visibility, TimeElapsed);
		}

		// update train
		internal static void UpdateTrain(Train Train, double TimeElapsed) {
			if (!Train.Disposed) {
				if (!Train.IsBogusTrain) {
					UpdateTrainPhysicsAndControls(Train, TimeElapsed);
					// arcade mode messages
					if (Interface.CurrentOptions.GameMode == Interface.GameMode.Arcade) {
						if (Train == TrainManager.PlayerTrain & Train.Specs.Security.Mode != TrainManager.SecuritySystem.Atc) {
							if (Train.Specs.CurrentAverageSpeed > Train.CurrentRouteLimit) {
								Game.AddMessage(Interface.GetInterfaceString("message_route_overspeed"), Game.MessageDependency.RouteLimit, Interface.GameMode.Arcade, Game.MessageColor.Orange, double.PositiveInfinity);
							}
							if (Train.CurrentSectionLimit == 0.0) {
								Game.AddMessage(Interface.GetInterfaceString("message_signal_stop"), Game.MessageDependency.SectionLimit, Interface.GameMode.Normal, Game.MessageColor.Red, double.PositiveInfinity);
							} else if (Train.Specs.CurrentAverageSpeed > Train.CurrentSectionLimit) {
								Game.AddMessage(Interface.GetInterfaceString("message_signal_overspeed"), Game.MessageDependency.SectionLimit, Interface.GameMode.Normal, Game.MessageColor.Orange, double.PositiveInfinity);
							}
						}
					}
				}
				if (Train.AI != null) {
					Train.AI.Trigger(Train);
				}
			}
		}

		// update trains
		internal static void UpdateTrains(double TimeElapsed) {
			// individual trains
			for (int i = 0; i < Trains.Length; i++) {
				UpdateTrain(Trains[i], TimeElapsed);
			}
			// detect collision
			if (!Game.MinimalisticSimulation & Interface.CurrentOptions.Collisions) {
				for (int i = 0; i < Trains.Length; i++) {
					// with other trains
					if (!Trains[i].Disposed & !Trains[i].IsBogusTrain) {
						double a = Trains[i].Cars[0].FrontAxle.Follower.TrackPosition - Trains[i].Cars[0].FrontAxlePosition + 0.5 * Trains[i].Cars[0].Length;
						double b = Trains[i].Cars[Trains[i].Cars.Length - 1].RearAxle.Follower.TrackPosition - Trains[i].Cars[Trains[i].Cars.Length - 1].RearAxlePosition - 0.5 * Trains[i].Cars[0].Length;
						for (int j = i + 1; j < Trains.Length; j++) {
							if (!Trains[j].Disposed & !Trains[j].IsBogusTrain) {
								double c = Trains[j].Cars[0].FrontAxle.Follower.TrackPosition - Trains[j].Cars[0].FrontAxlePosition + 0.5 * Trains[j].Cars[0].Length;
								double d = Trains[j].Cars[Trains[j].Cars.Length - 1].RearAxle.Follower.TrackPosition - Trains[j].Cars[Trains[j].Cars.Length - 1].RearAxlePosition - 0.5 * Trains[j].Cars[0].Length;
								if (a > d & b < c) {
									if (a > c) {
										// i > j
										int k = Trains[i].Cars.Length - 1;
										if (Trains[i].Cars[k].Specs.CurrentSpeed < Trains[j].Cars[0].Specs.CurrentSpeed) {
											double v = Trains[j].Cars[0].Specs.CurrentSpeed - Trains[i].Cars[k].Specs.CurrentSpeed;
											double s = (Trains[i].Cars[k].Specs.CurrentSpeed * Trains[i].Cars[k].Specs.Mass + Trains[j].Cars[0].Specs.CurrentSpeed * Trains[j].Cars[0].Specs.Mass) / (Trains[i].Cars[k].Specs.Mass + Trains[j].Cars[0].Specs.Mass);
											Trains[i].Cars[k].Specs.CurrentSpeed = s;
											Trains[j].Cars[0].Specs.CurrentSpeed = s;
											double e = 0.5 * (c - b) + 0.0001;
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[k].FrontAxle.Follower, Trains[i].Cars[k].FrontAxle.Follower.TrackPosition + e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[k].RearAxle.Follower, Trains[i].Cars[k].RearAxle.Follower.TrackPosition + e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[j].Cars[0].FrontAxle.Follower, Trains[j].Cars[0].FrontAxle.Follower.TrackPosition - e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[j].Cars[0].RearAxle.Follower, Trains[j].Cars[0].RearAxle.Follower.TrackPosition - e, true, true);
											if (Interface.CurrentOptions.Derailments) {
												double f = 2.0 / (Trains[i].Cars[k].Specs.Mass + Trains[j].Cars[0].Specs.Mass);
												double fi = Trains[j].Cars[0].Specs.Mass * f;
												double fj = Trains[i].Cars[k].Specs.Mass * f;
												double vi = v * fi;
												double vj = v * fj;
												if (vi > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[k].Derailed = true;
												if (vj > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[i].Derailed = true;
											}
											// adjust cars for train i
											for (int h = Trains[i].Cars.Length - 2; h >= 0; h--) {
												a = Trains[i].Cars[h + 1].FrontAxle.Follower.TrackPosition - Trains[i].Cars[h + 1].FrontAxlePosition + 0.5 * Trains[i].Cars[h + 1].Length;
												b = Trains[i].Cars[h].RearAxle.Follower.TrackPosition - Trains[i].Cars[h].RearAxlePosition - 0.5 * Trains[i].Cars[h].Length;
												d = b - a - Trains[i].Couplers[h].MinimumDistanceBetweenCars;
												if (d < 0.0) {
													d -= 0.0001;
													TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].FrontAxle.Follower, Trains[i].Cars[h].FrontAxle.Follower.TrackPosition - d, true, true);
													TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].RearAxle.Follower, Trains[i].Cars[h].RearAxle.Follower.TrackPosition - d, true, true);
													if (Interface.CurrentOptions.Derailments) {
														double f = 2.0 / (Trains[i].Cars[h + 1].Specs.Mass + Trains[i].Cars[h].Specs.Mass);
														double fi = Trains[i].Cars[h + 1].Specs.Mass * f;
														double fj = Trains[i].Cars[h].Specs.Mass * f;
														double vi = v * fi;
														double vj = v * fj;
														if (vi > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[h + 1].Derailed = true;
														if (vj > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[h].Derailed = true;
													}
													Trains[i].Cars[h].Specs.CurrentSpeed = Trains[i].Cars[h + 1].Specs.CurrentSpeed;
												}
											}
											// adjust cars for train j
											for (int h = 1; h < Trains[j].Cars.Length; h++) {
												a = Trains[j].Cars[h - 1].RearAxle.Follower.TrackPosition - Trains[j].Cars[h - 1].RearAxlePosition - 0.5 * Trains[j].Cars[h - 1].Length;
												b = Trains[j].Cars[h].FrontAxle.Follower.TrackPosition - Trains[j].Cars[h].FrontAxlePosition + 0.5 * Trains[j].Cars[h].Length;
												d = a - b - Trains[j].Couplers[h - 1].MinimumDistanceBetweenCars;
												if (d < 0.0) {
													d -= 0.0001;
													TrackManager.UpdateTrackFollower(ref Trains[j].Cars[h].FrontAxle.Follower, Trains[j].Cars[h].FrontAxle.Follower.TrackPosition + d, true, true);
													TrackManager.UpdateTrackFollower(ref Trains[j].Cars[h].RearAxle.Follower, Trains[j].Cars[h].RearAxle.Follower.TrackPosition + d, true, true);
													if (Interface.CurrentOptions.Derailments) {
														double f = 2.0 / (Trains[j].Cars[h - 1].Specs.Mass + Trains[j].Cars[h].Specs.Mass);
														double fi = Trains[j].Cars[h - 1].Specs.Mass * f;
														double fj = Trains[j].Cars[h].Specs.Mass * f;
														double vi = v * fi;
														double vj = v * fj;
														if (vi > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[h - 1].Derailed = true;
														if (vj > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[h].Derailed = true;
													}
													Trains[j].Cars[h].Specs.CurrentSpeed = Trains[j].Cars[h - 1].Specs.CurrentSpeed;
												}
											}
										}
									} else {
										// i < j
										int k = Trains[j].Cars.Length - 1;
										if (Trains[i].Cars[0].Specs.CurrentSpeed > Trains[j].Cars[k].Specs.CurrentSpeed) {
											double v = Trains[i].Cars[0].Specs.CurrentSpeed - Trains[j].Cars[k].Specs.CurrentSpeed;
											double s = (Trains[i].Cars[0].Specs.CurrentSpeed * Trains[i].Cars[0].Specs.Mass + Trains[j].Cars[k].Specs.CurrentSpeed * Trains[j].Cars[k].Specs.Mass) / (Trains[i].Cars[0].Specs.Mass + Trains[j].Cars[k].Specs.Mass);
											Trains[i].Cars[0].Specs.CurrentSpeed = s;
											Trains[j].Cars[k].Specs.CurrentSpeed = s;
											double e = 0.5 * (a - d) + 0.0001;
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[0].FrontAxle.Follower, Trains[i].Cars[0].FrontAxle.Follower.TrackPosition - e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[0].RearAxle.Follower, Trains[i].Cars[0].RearAxle.Follower.TrackPosition - e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[j].Cars[k].FrontAxle.Follower, Trains[j].Cars[k].FrontAxle.Follower.TrackPosition + e, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[j].Cars[k].RearAxle.Follower, Trains[j].Cars[k].RearAxle.Follower.TrackPosition + e, true, true);
											if (Interface.CurrentOptions.Derailments) {
												double f = 2.0 / (Trains[i].Cars[0].Specs.Mass + Trains[j].Cars[k].Specs.Mass);
												double fi = Trains[j].Cars[k].Specs.Mass * f;
												double fj = Trains[i].Cars[0].Specs.Mass * f;
												double vi = v * fi;
												double vj = v * fj;
												if (vi > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[0].Derailed = true;
												if (vj > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[k].Derailed = true;
											}
											// adjust cars for train i
											for (int h = 1; h < Trains[i].Cars.Length; h++) {
												a = Trains[i].Cars[h - 1].RearAxle.Follower.TrackPosition - Trains[i].Cars[h - 1].RearAxlePosition - 0.5 * Trains[i].Cars[h - 1].Length;
												b = Trains[i].Cars[h].FrontAxle.Follower.TrackPosition - Trains[i].Cars[h].FrontAxlePosition + 0.5 * Trains[i].Cars[h].Length;
												d = a - b - Trains[i].Couplers[h - 1].MinimumDistanceBetweenCars;
												if (d < 0.0) {
													d -= 0.0001;
													TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].FrontAxle.Follower, Trains[i].Cars[h].FrontAxle.Follower.TrackPosition + d, true, true);
													TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].RearAxle.Follower, Trains[i].Cars[h].RearAxle.Follower.TrackPosition + d, true, true);
													if (Interface.CurrentOptions.Derailments) {
														double f = 2.0 / (Trains[i].Cars[h - 1].Specs.Mass + Trains[i].Cars[h].Specs.Mass);
														double fi = Trains[i].Cars[h - 1].Specs.Mass * f;
														double fj = Trains[i].Cars[h].Specs.Mass * f;
														double vi = v * fi;
														double vj = v * fj;
														if (vi > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[h - 1].Derailed = true;
														if (vj > Game.CriticalCollisionSpeedDifference) Trains[i].Cars[h].Derailed = true;
													}
													Trains[i].Cars[h].Specs.CurrentSpeed = Trains[i].Cars[h - 1].Specs.CurrentSpeed;
												}
											}
											// adjust cars for train j
											for (int h = Trains[j].Cars.Length - 2; h >= 0; h--) {
												a = Trains[j].Cars[h + 1].FrontAxle.Follower.TrackPosition - Trains[j].Cars[h + 1].FrontAxlePosition + 0.5 * Trains[j].Cars[h + 1].Length;
												b = Trains[j].Cars[h].RearAxle.Follower.TrackPosition - Trains[j].Cars[h].RearAxlePosition - 0.5 * Trains[j].Cars[h].Length;
												d = b - a - Trains[j].Couplers[h].MinimumDistanceBetweenCars;
												if (d < 0.0) {
													d -= 0.0001;
													TrackManager.UpdateTrackFollower(ref Trains[j].Cars[h].FrontAxle.Follower, Trains[j].Cars[h].FrontAxle.Follower.TrackPosition - d, true, true);
													TrackManager.UpdateTrackFollower(ref Trains[j].Cars[h].RearAxle.Follower, Trains[j].Cars[h].RearAxle.Follower.TrackPosition - d, true, true);
													if (Interface.CurrentOptions.Derailments) {
														double f = 2.0 / (Trains[j].Cars[h + 1].Specs.Mass + Trains[j].Cars[h].Specs.Mass);
														double fi = Trains[j].Cars[h + 1].Specs.Mass * f;
														double fj = Trains[j].Cars[h].Specs.Mass * f;
														double vi = v * fi;
														double vj = v * fj;
														if (vi > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[h + 1].Derailed = true;
														if (vj > Game.CriticalCollisionSpeedDifference) Trains[j].Cars[h].Derailed = true;
													}
													Trains[j].Cars[h].Specs.CurrentSpeed = Trains[j].Cars[h + 1].Specs.CurrentSpeed;
												}
											}
										}
									}
								}
							}

						}
					}
					// with buffers
					if (i == PlayerTrain.TrainIndex) {
						double a = Trains[i].Cars[0].FrontAxle.Follower.TrackPosition - Trains[i].Cars[0].FrontAxlePosition + 0.5 * Trains[i].Cars[0].Length;
						double b = Trains[i].Cars[Trains[i].Cars.Length - 1].RearAxle.Follower.TrackPosition - Trains[i].Cars[Trains[i].Cars.Length - 1].RearAxlePosition - 0.5 * Trains[i].Cars[0].Length;
						for (int j = 0; j < Game.BufferTrackPositions.Length; j++) {
							if (a > Game.BufferTrackPositions[j] & b < Game.BufferTrackPositions[j]) {
								a += 0.0001; b -= 0.0001;
								double da = a - Game.BufferTrackPositions[j];
								double db = Game.BufferTrackPositions[j] - b;
								if (da < db) {
									// front
									TrackManager.UpdateTrackFollower(ref Trains[i].Cars[0].FrontAxle.Follower, Trains[i].Cars[0].FrontAxle.Follower.TrackPosition - da, true, true);
									TrackManager.UpdateTrackFollower(ref Trains[i].Cars[0].RearAxle.Follower, Trains[i].Cars[0].RearAxle.Follower.TrackPosition - da, true, true);
									if (Interface.CurrentOptions.Derailments && Math.Abs(Trains[i].Cars[0].Specs.CurrentSpeed) > Game.CriticalCollisionSpeedDifference) {
										Trains[i].Cars[0].Derailed = true;
									}
									Trains[i].Cars[0].Specs.CurrentSpeed = 0.0;
									for (int h = 1; h < Trains[i].Cars.Length; h++) {
										a = Trains[i].Cars[h - 1].RearAxle.Follower.TrackPosition - Trains[i].Cars[h - 1].RearAxlePosition - 0.5 * Trains[i].Cars[h - 1].Length;
										b = Trains[i].Cars[h].FrontAxle.Follower.TrackPosition - Trains[i].Cars[h].FrontAxlePosition + 0.5 * Trains[i].Cars[h].Length;
										double d = a - b - Trains[i].Couplers[h - 1].MinimumDistanceBetweenCars;
										if (d < 0.0) {
											d -= 0.0001;
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].FrontAxle.Follower, Trains[i].Cars[h].FrontAxle.Follower.TrackPosition + d, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].RearAxle.Follower, Trains[i].Cars[h].RearAxle.Follower.TrackPosition + d, true, true);
											if (Interface.CurrentOptions.Derailments && Math.Abs(Trains[i].Cars[h].Specs.CurrentSpeed) > Game.CriticalCollisionSpeedDifference) {
												Trains[i].Cars[h].Derailed = true;
											}
											Trains[i].Cars[h].Specs.CurrentSpeed = 0.0;
										}
									}
								} else {
									// rear
									int c = Trains[i].Cars.Length - 1;
									TrackManager.UpdateTrackFollower(ref Trains[i].Cars[c].FrontAxle.Follower, Trains[i].Cars[c].FrontAxle.Follower.TrackPosition + db, true, true);
									TrackManager.UpdateTrackFollower(ref Trains[i].Cars[c].RearAxle.Follower, Trains[i].Cars[c].RearAxle.Follower.TrackPosition + db, true, true);
									if (Interface.CurrentOptions.Derailments && Math.Abs(Trains[i].Cars[c].Specs.CurrentSpeed) > Game.CriticalCollisionSpeedDifference) {
										Trains[i].Cars[c].Derailed = true;
									}
									Trains[i].Cars[c].Specs.CurrentSpeed = 0.0;
									for (int h = Trains[i].Cars.Length - 2; h >= 0; h--) {
										a = Trains[i].Cars[h + 1].FrontAxle.Follower.TrackPosition - Trains[i].Cars[h + 1].FrontAxlePosition + 0.5 * Trains[i].Cars[h + 1].Length;
										b = Trains[i].Cars[h].RearAxle.Follower.TrackPosition - Trains[i].Cars[h].RearAxlePosition - 0.5 * Trains[i].Cars[h].Length;
										double d = b - a - Trains[i].Couplers[h].MinimumDistanceBetweenCars;
										if (d < 0.0) {
											d -= 0.0001;
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].FrontAxle.Follower, Trains[i].Cars[h].FrontAxle.Follower.TrackPosition - d, true, true);
											TrackManager.UpdateTrackFollower(ref Trains[i].Cars[h].RearAxle.Follower, Trains[i].Cars[h].RearAxle.Follower.TrackPosition - d, true, true);
											if (Interface.CurrentOptions.Derailments && Math.Abs(Trains[i].Cars[h].Specs.CurrentSpeed) > Game.CriticalCollisionSpeedDifference) {
												Trains[i].Cars[h].Derailed = true;
											}
											Trains[i].Cars[h].Specs.CurrentSpeed = 0.0;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// dispose train
		internal static void DisposeTrain(Train Train) {
			if (!Train.Disposed) {
				Train.Disposed = true;
				for (int i = 0; i < Train.Cars.Length; i++) {
					int s = Train.Cars[i].CurrentSection;
					if (s >= 0) {
						for (int j = 0; j < Train.Cars[i].Sections[s].Elements.Length; j++) {
							Renderer.HideObject(Train.Cars[i].Sections[s].Elements[j].ObjectIndex);
						}
					}
				}
				SoundManager.StopAllSounds(Train, true);
				for (int i = 0; i < Game.Sections.Length; i++) {
					Game.Sections[i].Leave(Train);
				}
				if (Game.Sections.Length != 0) {
					Game.UpdateSection(Game.Sections.Length - 1);
				}
			}
		}

		// synchronize train
		private static void SynchronizeTrain(Train Train) {
			for (int i = 0; i < Train.Cars.Length; i++) {
				double s = 0.5 * (Train.Cars[i].FrontAxle.Follower.TrackPosition + Train.Cars[i].RearAxle.Follower.TrackPosition);
				double d = 0.5 * (Train.Cars[i].FrontAxle.Follower.TrackPosition - Train.Cars[i].RearAxle.Follower.TrackPosition);
				TrackManager.UpdateTrackFollower(ref Train.Cars[i].FrontAxle.Follower, s + d, true, true);
				TrackManager.UpdateTrackFollower(ref Train.Cars[i].RearAxle.Follower, s - d, true, true);
			}
		}

		// update train station
		private static void UpdateTrainStation(Train Train, double TimeElapsed) {
			if (Train.Station >= 0) {
				int i = Train.Station;
				int n = Game.GetStopIndex(Train.Station, Train.Cars.Length);
				double tf = 5.0, tb = 5.0;
				if (n >= 0) {
					double p0 = Train.Cars[0].FrontAxle.Follower.TrackPosition - Train.Cars[0].FrontAxlePosition + 0.5 * Train.Cars[0].Length;
					double p1 = Game.Stations[i].Stops[n].TrackPosition;
					tf = Game.Stations[i].Stops[n].ForwardTolerance;
					tb = Game.Stations[i].Stops[n].BackwardTolerance;
					Train.StationDistanceToStopPoint = p1 - p0;
				} else {
					Train.StationDistanceToStopPoint = 0.0;
				}
				if (Train.StationState == TrainStopState.Pending) {
					Train.StationDepartureSoundPlayed = false;
					if (Game.Stations[i].StopAtStation) {
						Train.StationDepartureSoundPlayed = false;
						// automatically open doors
						if (Train.Specs.DoorOpenMode != DoorMode.Manual) {
							if ((GetDoorsState(Train, Game.Stations[i].OpenLeftDoors, Game.Stations[i].OpenRightDoors) & TrainDoorState.AllOpened) == 0) {
								if (Train.Specs.CurrentAverageSpeed > -0.00277777777777778 & Train.Specs.CurrentAverageSpeed < 0.00277777777777778 & Train.Specs.CurrentPowerNotch.Driver == 0) {
									if (Train.StationDistanceToStopPoint < tb & -Train.StationDistanceToStopPoint < tf) {
										OpenTrainDoors(Train, Game.Stations[i].OpenLeftDoors, Game.Stations[i].OpenRightDoors);
									}
								}
							}
						}
						// detect arrival
						if (Train.Specs.CurrentAverageSpeed > -0.277777777777778 & Train.Specs.CurrentAverageSpeed < 0.277777777777778) {
							bool left, right;
							if (Game.Stations[i].OpenLeftDoors) {
								left = false;
								for (int j = 0; j < Train.Cars.Length; j++) {
									if (Train.Cars[j].Specs.AnticipatedLeftDoorsOpened) {
										left = true; break;
									}
								}
							} else {
								left = true;
							}
							if (Game.Stations[i].OpenRightDoors) {
								right = false;
								for (int j = 0; j < Train.Cars.Length; j++) {
									if (Train.Cars[j].Specs.AnticipatedRightDoorsOpened) {
										right = true; break;
									}
								}
							} else {
								right = true;
							}
							if (left & right) {
								// arrival
								Train.StationState = TrainStopState.Boarding;
								Train.StationAdjust = false;
								if (Train.Cars[Train.DriverCar].Sounds.Halt.SoundBufferIndex >= 0 && SoundManager.IsPlaying(Train.Cars[Train.DriverCar].Sounds.Halt.SoundSourceIndex)) {
									SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Halt.SoundSourceIndex);
								}
								int snd = Game.Stations[i].ArrivalSoundIndex;
								if (snd >= 0) {
									World.Vector3D pos = Game.Stations[i].SoundOrigin;
									SoundManager.PlaySound(snd, pos, SoundManager.Importance.DontCare, false);
								}
								Train.StationArrivalTime = Game.SecondsSinceMidnight;
								Train.StationDepartureTime = Game.Stations[i].DepartureTime - Train.PretrainAheadTimetable;
								if (Train.StationDepartureTime - Game.SecondsSinceMidnight < Game.Stations[i].StopTime) {
									Train.StationDepartureTime = Game.SecondsSinceMidnight + Game.Stations[i].StopTime;
								}
								Train.Passengers.PassengerRatio = Game.Stations[i].PassengerRatio;
								if (Train == PlayerTrain) {
									double early = 0.0;
									if (Game.Stations[i].ArrivalTime >= 0.0) {
										early = (Game.Stations[i].ArrivalTime - Train.PretrainAheadTimetable) - Train.StationArrivalTime;
									} else {
										early = 0.0;
									}
									string s;
									if (early < -1.0) {
										s = Interface.GetInterfaceString("message_station_arrival_late");
									} else if (early > 1.0) {
										s = Interface.GetInterfaceString("message_station_arrival_early");
									} else {
										s = Interface.GetInterfaceString("message_station_arrival");
									}
									System.Globalization.CultureInfo Culture = System.Globalization.CultureInfo.InvariantCulture;
									TimeSpan a = TimeSpan.FromSeconds(Math.Abs(early));
									string b = a.Hours.ToString("00", Culture) + ":" + a.Minutes.ToString("00", Culture) + ":" + a.Seconds.ToString("00", Culture);
									if (Train.StationDistanceToStopPoint < -0.1) {
										s += Interface.GetInterfaceString("message_delimiter") + Interface.GetInterfaceString("message_station_overrun");
									} else if (Train.StationDistanceToStopPoint > 0.1) {
										s += Interface.GetInterfaceString("message_delimiter") + Interface.GetInterfaceString("message_station_underrun");
									}
									double d = Math.Abs(Train.StationDistanceToStopPoint);
									string c = d.ToString("0.0", Culture);
									if (Game.Stations[i].IsTerminalStation) {
										s += Interface.GetInterfaceString("message_delimiter") + Interface.GetInterfaceString("message_station_terminal");
									}
									s = s.Replace("[name]", Game.Stations[i].Name);
									s = s.Replace("[time]", b);
									s = s.Replace("[difference]", c);
									Game.AddMessage(s, Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Blue, Game.SecondsSinceMidnight + 10.0);
									if (!Game.Stations[i].IsTerminalStation) {
										s = Interface.GetInterfaceString("message_station_deadline");
										Game.AddMessage(s, Game.MessageDependency.Station, Interface.GameMode.Normal, Game.MessageColor.Blue, double.PositiveInfinity);
									}
									if (Train.Specs.Security.Mode != SecuritySystem.Bve4Plugin) {
										if (Train.Specs.Security.Atc.Available & !Train.Specs.Security.Atc.AutomaticSwitch) {
											if (Game.Stations[i].SecuritySystem == Game.SecuritySystem.Ats & Train.Specs.Security.Mode != SecuritySystem.AtsSN & Train.Specs.Security.Mode != SecuritySystem.AtsP) {
												s = Interface.GetInterfaceString("message_station_security");
												s = s.Replace("[system]", "ATS");
												Game.AddMessage(s, Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Orange, Game.SecondsSinceMidnight + 5.0);
											} else if (Game.Stations[i].SecuritySystem == Game.SecuritySystem.Atc & Train.Specs.Security.Mode != SecuritySystem.Atc) {
												s = Interface.GetInterfaceString("message_station_security");
												s = s.Replace("[system]", "ATC");
												Game.AddMessage(s, Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Orange, Game.SecondsSinceMidnight + 5.0);
											}
										}
									}
									Timetable.UpdateCustomTimetable(Game.Stations[i].TimetableDaytimeTexture, Game.Stations[i].TimetableNighttimeTexture);
								}
								// atc switch
								if (Train.Specs.Security.Atc.Available & Train.Specs.Security.Atc.AutomaticSwitch) {
									if (Game.Stations[i].SecuritySystem == Game.SecuritySystem.Ats & Train.Specs.Security.Mode != SecuritySystem.AtsSN & Train.Specs.Security.Mode != SecuritySystem.AtsP) {
										if (Train.Specs.Security.Ats.AtsAvailable) {
											Train.Specs.Security.ModeChange = SecuritySystem.AtsSN;
										}
									} else if (Game.Stations[i].SecuritySystem == Game.SecuritySystem.Atc & Train.Specs.Security.Mode != SecuritySystem.Atc) {
										Train.Specs.Security.ModeChange = SecuritySystem.Atc;
									}
								}
							} else if (Train.Specs.CurrentAverageSpeed > -0.277777777777778 & Train.Specs.CurrentAverageSpeed < 0.277777777777778) {
								// correct stop position
								if (!Train.StationAdjust & (Train.StationDistanceToStopPoint > tb | Train.StationDistanceToStopPoint < -tf)) {
									int snd = Train.Cars[Train.DriverCar].Sounds.Adjust.SoundBufferIndex;
									if (snd >= 0) {
										World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Adjust.Position;
										SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
									}
									if (Train == TrainManager.PlayerTrain) {
										Game.AddMessage(Interface.GetInterfaceString("message_station_correct"), Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Orange, Game.SecondsSinceMidnight + 5.0);
									}
									Train.StationAdjust = true;
								}
							} else {
								Train.StationAdjust = false;
							}
						}
					}
				} else if (Train.StationState == TrainStopState.Boarding) {
					// automatically close doors
					if (Train.Specs.DoorCloseMode != DoorMode.Manual & !Game.Stations[i].IsTerminalStation) {
						if (Game.SecondsSinceMidnight >= Train.StationDepartureTime - 1.0 / Train.Cars[Train.DriverCar].Specs.DoorCloseFrequency) {
							if ((GetDoorsState(Train, true, true) & TrainDoorState.AllClosed) == 0) {
								CloseTrainDoors(Train, true, true);
							}
						}
					}
					// detect departure
					bool left, right;
					if (!Game.Stations[i].OpenLeftDoors & !Game.Stations[i].OpenRightDoors) {
						left = true;
						right = true;
					} else {
						if (Game.Stations[i].OpenLeftDoors) {
							left = false;
							for (int j = 0; j < Train.Cars.Length; j++) {
								for (int k = 0; k < Train.Cars[j].Specs.Doors.Length; k++) {
									if (Train.Cars[j].Specs.Doors[k].State != 0.0) {
										left = true; break;
									}
								} if (left) break;
							}
						} else {
							left = false;
						}
						if (Game.Stations[i].OpenRightDoors) {
							right = false;
							for (int j = 0; j < Train.Cars.Length; j++) {
								for (int k = 0; k < Train.Cars[j].Specs.Doors.Length; k++) {
									if (Train.Cars[j].Specs.Doors[k].State != 0.0) {
										right = true; break;
									}
								} if (right) break;
							}
						} else {
							right = false;
						}
					}
					if (left | right) {
						// departure message
						if (Game.SecondsSinceMidnight > Train.StationDepartureTime) {
							Train.StationState = TrainStopState.Completed;
							if (Train == PlayerTrain & !Game.Stations[i].IsTerminalStation) {
								if (!Game.Stations[i].OpenLeftDoors & !Game.Stations[i].OpenRightDoors | Train.Specs.DoorCloseMode != DoorMode.Manual) {
									Game.AddMessage(Interface.GetInterfaceString("message_station_depart"), Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Blue, Game.SecondsSinceMidnight + 5.0);
								} else {
									Game.AddMessage(Interface.GetInterfaceString("message_station_depart_closedoors"), Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Blue, Game.SecondsSinceMidnight + 5.0);
								}
							}
						}
						// passengers boarding
						for (int j = 0; j < Train.Cars.Length; j++) {
							double r = 2.0 * Game.Stations[i].PassengerRatio * TimeElapsed;
							if (r >= Game.Generator.NextDouble()) {
								int d = (int)Math.Floor(Game.Generator.NextDouble() * (double)Train.Cars[j].Specs.Doors.Length);
								if (Train.Cars[j].Specs.Doors[d].State == 1.0) {
									Train.Cars[j].Specs.CurrentRollShakeDirection += (double)Train.Cars[j].Specs.Doors[d].Direction;
								}
							}
						}
					} else {
						Train.StationState = TrainStopState.Completed;
						if (Train == PlayerTrain & !Game.Stations[i].IsTerminalStation) {
							Game.AddMessage(Interface.GetInterfaceString("message_station_depart"), Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Blue, Game.SecondsSinceMidnight + 5.0);
						}
					}
					// departure sound
					if (!Train.StationDepartureSoundPlayed) {
						int snd = Game.Stations[i].DepartureSoundIndex;
						if (snd >= 0) {
							double dur = SoundManager.GetSoundLength(snd);
							if (Game.SecondsSinceMidnight >= Train.StationDepartureTime - dur) {
								SoundManager.PlaySound(snd, Game.Stations[i].SoundOrigin, SoundManager.Importance.DontCare, false);
								Train.StationDepartureSoundPlayed = true;
							}
						}
					}
				}
			} else {
				Train.StationState = TrainStopState.Pending;
			}
			// automatically close doors
			if (Train.Specs.DoorCloseMode == DoorMode.Automatic) {
				if (Train.Station == -1 | Train.StationState == TrainStopState.Completed) {
					if ((GetDoorsState(Train, true, true) & TrainDoorState.AllClosed) == 0) {
						CloseTrainDoors(Train, true, true);
					}
				}
			}
		}

		// update train doors
		private static void UpdateTrainDoors(Train Train, double TimeElapsed) {
			bool olddoorsopen = false;
			bool newdoorsopen = false;
			for (int i = 0; i < Train.Cars.Length; i++) {
				bool ld = Train.Cars[i].Specs.AnticipatedLeftDoorsOpened;
				bool rd = Train.Cars[i].Specs.AnticipatedRightDoorsOpened;
				double os = Train.Cars[i].Specs.DoorOpenFrequency;
				double cs = Train.Cars[i].Specs.DoorCloseFrequency;
				for (int j = 0; j < Train.Cars[i].Specs.Doors.Length; j++) {
					if (Train.Cars[i].Specs.Doors[j].Direction == -1) {
						// left door
						if (Train.Cars[i].Specs.Doors[j].State > 0.0) olddoorsopen = true;
						if (ld) {
							// open
							Train.Cars[i].Specs.Doors[j].State += os * TimeElapsed;
							if (Train.Cars[i].Specs.Doors[j].State > 1.0) Train.Cars[i].Specs.Doors[j].State = 1.0;
						} else {
							// close
							Train.Cars[i].Specs.Doors[j].State -= cs * TimeElapsed;
							if (Train.Cars[i].Specs.Doors[j].State < 0.0) Train.Cars[i].Specs.Doors[j].State = 0.0;
						}
						if (Train.Cars[i].Specs.Doors[j].State > 0.0) newdoorsopen = true;
					} else if (Train.Cars[i].Specs.Doors[j].Direction == 1) {
						// right door
						if (Train.Cars[i].Specs.Doors[j].State > 0.0) olddoorsopen = true;
						if (rd) {
							// open
							Train.Cars[i].Specs.Doors[j].State += os * TimeElapsed;
							if (Train.Cars[i].Specs.Doors[j].State > 1.0) Train.Cars[i].Specs.Doors[j].State = 1.0;
						} else {
							// close
							Train.Cars[i].Specs.Doors[j].State -= cs * TimeElapsed;
							if (Train.Cars[i].Specs.Doors[j].State < 0.0) Train.Cars[i].Specs.Doors[j].State = 0.0;
						}
						if (Train.Cars[i].Specs.Doors[j].State > 0.0) newdoorsopen = true;
					}
				}
			}
			// door changed
			if (olddoorsopen & !newdoorsopen) {
				int snd = Train.Cars[Train.DriverCar].Sounds.PilotLampOn.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.PilotLampOn.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
				if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
					PluginManager.UpdateDoors(true);
				}
			} else if (!olddoorsopen & newdoorsopen) {
				int snd = Train.Cars[Train.DriverCar].Sounds.PilotLampOff.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.PilotLampOff.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
				if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
					PluginManager.UpdateDoors(false);
				}
			}
		}

		// train doors
		internal static void OpenTrainDoors(Train Train, bool Left, bool Right) {
			bool sl = false, sr = false;
			for (int i = 0; i < Train.Cars.Length; i++) {
				if (Left & !Train.Cars[i].Specs.AnticipatedLeftDoorsOpened) {
					Train.Cars[i].Specs.AnticipatedLeftDoorsOpened = true;
					sl = true;
				}
				if (Right & !Train.Cars[i].Specs.AnticipatedRightDoorsOpened) {
					Train.Cars[i].Specs.AnticipatedRightDoorsOpened = true;
					sr = true;
				}
			}
			if (sl) {
				for (int i = 0; i < Train.Cars.Length; i++) {
					int snd = Train.Cars[i].Sounds.DoorOpenL.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[i].Sounds.DoorOpenL.Position;
						SoundManager.PlaySound(snd, Train, i, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
			if (sr) {
				for (int i = 0; i < Train.Cars.Length; i++) {
					int snd = Train.Cars[i].Sounds.DoorOpenR.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[i].Sounds.DoorOpenR.Position;
						SoundManager.PlaySound(snd, Train, i, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
		}
		internal static void CloseTrainDoors(Train Train, bool Left, bool Right) {
			bool sl = false, sr = false;
			for (int i = 0; i < Train.Cars.Length; i++) {
				if (Left & Train.Cars[i].Specs.AnticipatedLeftDoorsOpened) {
					Train.Cars[i].Specs.AnticipatedLeftDoorsOpened = false;
					sl = true;
				}
				if (Right & Train.Cars[i].Specs.AnticipatedRightDoorsOpened) {
					Train.Cars[i].Specs.AnticipatedRightDoorsOpened = false;
					sr = true;
				}
			}
			if (sl) {
				for (int i = 0; i < Train.Cars.Length; i++) {
					int snd = Train.Cars[i].Sounds.DoorCloseL.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[i].Sounds.DoorCloseL.Position;
						SoundManager.PlaySound(snd, Train, i, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
			if (sr) {
				for (int i = 0; i < Train.Cars.Length; i++) {
					int snd = Train.Cars[i].Sounds.DoorCloseR.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[i].Sounds.DoorCloseR.Position;
						SoundManager.PlaySound(snd, Train, i, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
		}
		/// <summary>Specifies enumerated constants that can be combined to represent doors states.</summary>
		internal enum TrainDoorState {
			None = 0,
			/// <summary>Fully closed doors are present in the train.</summary>
			Closed = 1,
			/// <summary>Fully opened doors are present in the train.</summary>
			Opened = 2,
			/// <summary>Doors are present in the train which are neither fully closed nor fully opened.</summary>
			Mixed = 4,
			/// <summary>All doors in the train are fully closed.</summary>
			AllClosed = 8,
			/// <summary>All doors in the train are fully opened.</summary>
			AllOpened = 16,
			/// <summary>All doors in the train are neither fully closed nor fully opened.</summary>
			AllMixed = 32
		}
		/// <summary>Returns the combination of door states encountered in a train.</summary>
		/// <param name="Train">The train to consider.</param>
		/// <param name="Left">Whether to include left doors.</param>
		/// <param name="Right">Whether to include right doors.</param>
		/// <returns>A bit mask combining encountered door states.</returns>
		internal static TrainDoorState GetDoorsState(Train Train, bool Left, bool Right) {
			bool opened = false, closed = false, mixed = false;
			for (int i = 0; i < Train.Cars.Length; i++) {
				for (int j = 0; j < Train.Cars[i].Specs.Doors.Length; j++) {
					if (Left & Train.Cars[i].Specs.Doors[j].Direction == -1 | Right & Train.Cars[i].Specs.Doors[j].Direction == 1) {
						if (Train.Cars[i].Specs.Doors[j].State == 0.0) {
							closed = true;
						} else if (Train.Cars[i].Specs.Doors[j].State == 1.0) {
							opened = true;
						} else {
							mixed = true;
						}
					}
				}
			}
			TrainDoorState Result = TrainDoorState.None;
			if (opened) Result |= TrainDoorState.Opened;
			if (closed) Result |= TrainDoorState.Closed;
			if (mixed) Result |= TrainDoorState.Mixed;
			if (opened & !closed & !mixed) Result |= TrainDoorState.AllOpened;
			if (!opened & closed & !mixed) Result |= TrainDoorState.AllClosed;
			if (!opened & !closed & mixed) Result |= TrainDoorState.AllMixed;
			return Result;
		}

		// update security system
		private static void UpdateSecuritySystem(Train Train, double TimeElapsed) {
			// plugin
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
				PluginManager.UpdatePlugin(Train);
				return;
			}
			// handles
			Train.Specs.CurrentReverser.Actual = Train.Specs.CurrentReverser.Driver;
			Train.Specs.CurrentPowerNotch.Security = Train.Specs.CurrentPowerNotch.Driver;
			Train.Specs.CurrentBrakeNotch.Security = Train.Specs.CurrentBrakeNotch.Driver;
			Train.Specs.AirBrake.Handle.Security = Train.Specs.AirBrake.Handle.Driver;
			Train.Specs.CurrentEmergencyBrake.Security = Train.Specs.CurrentEmergencyBrake.Driver;
			Train.Specs.CurrentHoldBrake.Actual = Train.Specs.CurrentHoldBrake.Driver;
			// mode change
			if (Train.Specs.Security.Mode != Train.Specs.Security.ModeChange & (Train.Specs.Security.State != SecurityState.Emergency | Train.Specs.Security.ModeChange == SecuritySystem.None | Train.Specs.Security.ModeChange == SecuritySystem.AtsSN)) {
				if (Train.Specs.Security.ModeChange != SecuritySystem.None) {
					int snd = Train.Cars[Train.DriverCar].Sounds.Ding.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ding.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				}
				if ((Train.Specs.Security.ModeChange == SecuritySystem.AtsSN | Train.Specs.Security.ModeChange == SecuritySystem.AtsP) & Train.Specs.Security.Mode == SecuritySystem.Atc) {
					int snd = Train.Cars[Train.DriverCar].Sounds.ToAts.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.ToAts.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				} else if (Train.Specs.Security.ModeChange == SecuritySystem.Atc & (Train.Specs.Security.Mode == SecuritySystem.AtsSN | Train.Specs.Security.Mode == SecuritySystem.AtsP)) {
					int snd = Train.Cars[Train.DriverCar].Sounds.ToAtc.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.ToAtc.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				}
				Train.Specs.Security.Mode = Train.Specs.Security.ModeChange;
				Train.Specs.Security.Ats.AtsPOverrideTime = double.NegativeInfinity;
			}
			// mode
			TrainPendingTransponder Transponder = Train.Specs.Security.GetPendingTransponder();
			if (Transponder.SectionIndex == (int)TrackManager.TransponderSpecialSection.NextRedSection) {
				// next red section
				int s = Train.CurrentSectionIndex;
				if (s >= 0) {
					s = Game.Sections[s].NextSection;
					while (s >= 0) {
						int a = Game.Sections[s].CurrentAspect;
						if (a >= 0) {
							if (Game.Sections[s].Aspects[a].Number == 0) {
								Transponder.SectionIndex = s;
								break;
							}
						} s = Game.Sections[s].NextSection;
					}
				}
			}
			bool KeepTransponderData = false;
			if (Train.Specs.Security.Mode != SecuritySystem.None) {
				// eb device
				if (Train.Specs.Security.Eb.Available) {
					if (Train.Specs.CurrentEmergencyBrake.Driver | Game.MinimalisticSimulation & Train != PlayerTrain) {
						Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
					} else {
						if (Train.Specs.Security.Eb.BellState == SecurityState.Normal) {
							if (Game.SecondsSinceMidnight - Train.Specs.Security.Eb.Time >= 60.0 & Math.Abs(Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed) >= 4.16666666666667) {
								Train.Specs.Security.Eb.BellState = SecurityState.Ringing;
								Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
								Train.Specs.Security.Eb.Reset = false;
								int snd = Train.Cars[Train.DriverCar].Sounds.Eb.SoundBufferIndex;
								if (snd >= 0) {
									World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Eb.Position;
									SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.Eb.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
								}
							} else if (Train.Specs.Security.Eb.Reset) {
								Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
								Train.Specs.Security.Eb.Reset = false;
							}
						} else if (Train.Specs.Security.Eb.BellState == SecurityState.Ringing) {
							if (Train.Specs.Security.Eb.Reset) {
								Train.Specs.Security.Eb.BellState = SecurityState.Normal;
								Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
								Train.Specs.Security.Eb.Reset = false;
								SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Eb.SoundSourceIndex);
							} else if (Game.SecondsSinceMidnight - Train.Specs.Security.Eb.Time >= 5.0) {
								Train.Specs.Security.Eb.BellState = SecurityState.Emergency;
								Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
							}
						} else if (Train.Specs.Security.Eb.BellState == SecurityState.Emergency) {
							SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Eb.SoundSourceIndex);
							if (Train.Specs.Security.Ats.AtsAvailable) {
								Train.Specs.Security.ModeChange = SecuritySystem.AtsSN;
							}
							Train.Specs.Security.State = SecurityState.Emergency;
						}
					}
				}
				// ats
				if (Train.Specs.Security.State == SecurityState.Initialization | Train.Specs.Security.State == SecurityState.Ringing | Train.Specs.Security.State == SecurityState.Emergency) {
					if (Train.Specs.Security.State == SecurityState.Initialization & Game.SecondsSinceMidnight - Train.Specs.Security.Ats.Time >= 1.0) {
						Train.Specs.Security.State = SecurityState.Normal;
						Train.Specs.Security.Ats.AtsPDistance = double.PositiveInfinity;
						Train.Specs.Security.Ats.AtsPTemporarySpeed = double.PositiveInfinity;
						Train.Specs.Security.Ats.AtsPPermanentSpeed = double.PositiveInfinity;
						Train.Specs.Security.Ats.AtsPOverride = false;
						Train.Specs.Security.Ats.AtsPOverrideTime = double.NegativeInfinity;
						int snd = Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundBufferIndex;
						if (snd >= 0 & Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex < 0) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.AtsCnt.Position;
							SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
						}
					} else if (Game.SecondsSinceMidnight - Train.Specs.Security.Ats.Time >= 5.0) {
						Train.Specs.Security.State = SecurityState.Emergency;
					}
					{
						int snd = Train.Cars[Train.DriverCar].Sounds.Ats.SoundBufferIndex;
						if (snd >= 0) {
							if (!SoundManager.IsPlaying(Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex)) {
								World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ats.Position;
								SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
							}
						}
					}
					if (Train.Specs.Security.State != SecurityState.Ringing) {
						Train.Specs.CurrentEmergencyBrake.Security = true;
					}
				} else {
					Train.Specs.Security.Ats.Time = Game.SecondsSinceMidnight;
					SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex);
				}
				// mode
				if (Train.Specs.Security.Mode == SecuritySystem.AtsSN) {
					// ats-sn
					if (Train.Specs.Security.State == SecurityState.Pattern | Train.Specs.Security.State == SecurityState.Service) {
						Train.Specs.Security.State = SecurityState.Normal;
					}
					int s = Transponder.SectionIndex;
					if (Transponder.Type == TrackManager.TransponderType.S) {
						if (s >= 0) {
							if (Game.Sections[s].Aspects[Game.Sections[s].CurrentAspect].Speed == 0.0) {
								Train.Specs.Security.State = SecurityState.Ringing;
							}
						} else {
							Train.Specs.Security.State = SecurityState.Ringing;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.Sn | Transponder.Type == TrackManager.TransponderType.AccidentalDeparture) {
						if (s >= 0) {
							if (Game.Sections[s].Aspects[Game.Sections[s].CurrentAspect].Speed == 0.0) {
								Train.Specs.Security.State = SecurityState.Emergency;
							}
						} else {
							Train.Specs.Security.State = SecurityState.Emergency;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.AtsPPatternOrigin | Transponder.Type == TrackManager.TransponderType.AtsPImmediateStop) {
						if (Train.Specs.Security.Ats.AtsPAvailable & Transponder.SwitchSubsystem) {
							Train.Specs.Security.ModeChange = SecuritySystem.AtsP;
							KeepTransponderData = true;
						}
					}
				} else if (Train.Specs.Security.Mode == SecuritySystem.AtsP) {
					// ats-p
					bool brkrel = Game.SecondsSinceMidnight - Train.Specs.Security.Ats.AtsPOverrideTime < 60.0;
					if (brkrel != Train.Specs.Security.Ats.AtsPOverride) {
						Train.Specs.Security.Ats.AtsPOverride = brkrel;
						int snd = Train.Cars[Train.DriverCar].Sounds.Ding.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ding.Position;
							SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
						}
					}
					if (!brkrel) {
						Train.Specs.Security.Ats.AtsPOverrideTime = double.NegativeInfinity;
					}
					if (Train.Specs.Security.State == SecurityState.Ringing | Train.Specs.Security.State == SecurityState.Emergency) {
						Train.Specs.Security.State = SecurityState.Normal;
					}
					SecurityState state = Train.Specs.Security.State;
					int s = Transponder.SectionIndex;
					if (Transponder.Type == TrackManager.TransponderType.S | Transponder.Type == TrackManager.TransponderType.Sn) {
						if (Train.Specs.Security.Ats.AtsAvailable & Transponder.SwitchSubsystem) {
							Train.Specs.Security.ModeChange = SecuritySystem.AtsSN;
							int snd = Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundBufferIndex;
							if (snd >= 0 & Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex < 0) {
								World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.AtsCnt.Position;
								SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
							}
							KeepTransponderData = true;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.AtsPPatternOrigin | Transponder.Type == TrackManager.TransponderType.AtsPImmediateStop) {
						if (s >= 0) {
							if (Transponder.Type == TrackManager.TransponderType.AtsPImmediateStop) {
								if (Game.Sections[s].Aspects[Game.Sections[s].CurrentAspect].Speed == 0.0) {
									Train.Specs.Security.Ats.AtsPDistance = 0.0;
								} else {
									Train.Specs.Security.Ats.AtsPDistance = double.PositiveInfinity;
								}
							} else {
								Train.Specs.Security.Ats.AtsPDistance = double.PositiveInfinity;
								int k = s; do {
									if (!Game.Sections[k].Invisible & Game.Sections[k].Aspects[Game.Sections[k].CurrentAspect].Speed == 0.0) {
										Train.Specs.Security.Ats.AtsPDistance = Game.Sections[k].TrackPosition - Train.Cars[0].FrontAxle.Follower.TrackPosition - 25.0;
										break;
									} k = Game.Sections[k].NextSection;
								} while (k >= 0);
							}
						} else {
							Train.Specs.Security.Ats.AtsPDistance = double.PositiveInfinity;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.AccidentalDeparture & Train.Specs.Security.Ats.AtsAvailable) {
						if (s < 0 || Game.Sections[s].Aspects[Game.Sections[s].CurrentAspect].Speed == 0.0) {
							Train.Specs.Security.ModeChange = SecuritySystem.AtsSN;
							Train.Specs.Security.State = SecurityState.Emergency;
							KeepTransponderData = true;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.AtsPTemporarySpeedRestriction) {
						if (Transponder.OptionalFloat >= 0.0) {
							Train.Specs.Security.Ats.AtsPTemporarySpeed = Transponder.OptionalFloat;
						}
					} else if (Transponder.Type == TrackManager.TransponderType.AtsPPermanentSpeedRestriction) {
						if (Transponder.OptionalFloat >= 0.0) {
							Train.Specs.Security.Ats.AtsPPermanentSpeed = Transponder.OptionalFloat;
						}
					}
					if (Train.Specs.Security.ModeChange != SecuritySystem.AtsSN) {
						if (Train.Specs.Security.Ats.AtsPDistance <= 0.0) {
							Train.Specs.Security.State = SecurityState.Service;
							Train.Specs.CurrentBrakeNotch.Security = Train.Specs.MaximumBrakeNotch;
							Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
						} else {
							double spd = Math.Abs(Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed);
							double dist = Train.Specs.Security.Ats.AtsPDistance;
							double patmax = double.PositiveInfinity;
							double patmin = double.PositiveInfinity;
							const double fac = 1.1547;
							const double invfac = 1.0 / fac;
							{ /// scan for temporary speed restrictions
								int i0 = Train.Cars[Train.DriverCar].FrontAxle.Follower.LastTrackElement;
								double p0 = Train.Cars[Train.DriverCar].FrontAxle.Follower.TrackPosition;
								double p = p0;
								double d = invfac * spd * spd + 50.0;
								double p1 = p + d;
								for (int i = i0; i < TrackManager.CurrentTrack.Elements.Length; i++) {
									p = TrackManager.CurrentTrack.Elements[i].StartingTrackPosition;
									for (int j = 0; j < TrackManager.CurrentTrack.Elements[i].Events.Length; j++) {
										TrackManager.TransponderEvent e = TrackManager.CurrentTrack.Elements[i].Events[j] as TrackManager.TransponderEvent;
										if (e != null) {
											if (e.Type == TrackManager.TransponderType.AtsPTemporarySpeedRestriction) {
												double pe = p + e.TrackPositionDelta;
												if (pe > p0 & pe < p1) {
													double r = e.OptionalFloat * invfac;
													r = r * r + 50.0 + pe - p0;
													if (r < dist) dist = r;
												}
											}
										}
									}
									if (p > p1) break;
								}
							}
							if (dist != double.PositiveInfinity) {
								patmin = dist > 50.0 ? fac * Math.Sqrt(dist - 50.0) : 0.0;
								patmax = dist > 0.0 ? fac * Math.Sqrt(dist) : 0.0;
								if (dist > 0.0 & Train.Cars[Train.DriverCar].Specs.BrakeDecelerationAtServiceMaximumPressure > 0.0) {
									double patmin0 = dist > 50.0 ? Math.Sqrt(2.0 * (dist - 50.0) * Train.Cars[Train.DriverCar].Specs.BrakeDecelerationAtServiceMaximumPressure) : 0.0;
									double patmax0 = Math.Sqrt(2.0 * dist * Train.Cars[Train.DriverCar].Specs.BrakeDecelerationAtServiceMaximumPressure);
									if (patmin0 < patmin) patmin = patmin0;
									if (patmax0 < patmax) patmax = patmax0;
								}
							}
							if (patmin > Train.Specs.Security.Ats.AtsPPermanentSpeed) {
								patmin = Train.Specs.Security.Ats.AtsPPermanentSpeed;
								double max = patmin + 1.4;
								if (patmax > max) patmax = max;
							}
							if (spd < Train.Specs.Security.Ats.AtsPTemporarySpeed) {
								Train.Specs.Security.Ats.AtsPTemporarySpeed = double.PositiveInfinity;
							}
							if (patmin > Train.Specs.Security.Ats.AtsPTemporarySpeed) {
								patmin = Train.Specs.Security.Ats.AtsPTemporarySpeed;
								double max = patmin + 1.4;
								if (patmax > max) patmax = max;
							}
							if (Train.Specs.Security.State == SecurityState.Service) {
								if (spd < patmin) {
									Train.Specs.Security.State = SecurityState.Normal;
								} else {
									Train.Specs.CurrentBrakeNotch.Security = Train.Specs.MaximumBrakeNotch;
									Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
								}
							} else if (spd > patmin) {
								if (spd > patmax) {
									Train.Specs.Security.State = SecurityState.Service;
									Train.Specs.CurrentBrakeNotch.Security = Train.Specs.MaximumBrakeNotch;
									Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
								} else {
									Train.Specs.Security.State = SecurityState.Pattern;
								}
							} else {
								Train.Specs.Security.State = SecurityState.Normal;
							}
							if (Train.Specs.Security.Ats.AtsPDistance != double.PositiveInfinity) {
								Train.Specs.Security.Ats.AtsPDistance -= Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed * TimeElapsed;
							}
						}
						if (Train.Specs.Security.State != state) {
							bool q = Train.Specs.Security.State == SecurityState.Service & state == SecurityState.Pattern | Train.Specs.Security.State == SecurityState.Pattern & state == SecurityState.Service;
							if (!q | !brkrel) {
								int snd = Train.Cars[Train.DriverCar].Sounds.Ding.SoundBufferIndex;
								if (snd >= 0) {
									World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ding.Position;
									SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
								}
							}
						}
						if (brkrel) {
							Train.Specs.CurrentBrakeNotch.Security = Train.Specs.CurrentBrakeNotch.Driver;
							Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
							Train.Specs.CurrentEmergencyBrake.Security = Train.Specs.CurrentEmergencyBrake.Driver;
						}
					}
				} else if (Train.Specs.Security.Mode == SecuritySystem.Atc) {
					// atc
					if (Train.Specs.Security.State != SecurityState.Normal & Train.Specs.Security.State != SecurityState.Service) {
						Train.Specs.Security.State = SecurityState.Normal;
					}
					if (Train.Specs.Security.Atc.Transmitting) {
						// limit
						double spd = Train.RouteLimits.Length > 0 ? Train.RouteLimits[Train.RouteLimits.Length - 1] : double.PositiveInfinity;
						// upcoming speed limits
						double Position = Train.Cars[0].FrontAxle.Follower.TrackPosition;
						double CurrentSpeed = Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed;
						double Deceleration = 0.4 * Train.Cars[Train.DriverCar].Specs.BrakeDecelerationAtServiceMaximumPressure;
						double LookAhead = 50.0 + 2.0 * (CurrentSpeed * CurrentSpeed) / (2.0 * Deceleration);
						{
							int lte = Train.Cars[0].FrontAxle.Follower.LastTrackElement;
							bool limit = false;
							for (int i = lte; i < TrackManager.CurrentTrack.Elements.Length; i++) {
								double stp = TrackManager.CurrentTrack.Elements[i].StartingTrackPosition;
								if (Position + LookAhead <= stp) break;
								int j;
								for (j = 0; j < TrackManager.CurrentTrack.Elements[i].Events.Length; j++) {
									if (!limit & TrackManager.CurrentTrack.Elements[i].Events[j] is TrackManager.LimitChangeEvent) {
										TrackManager.LimitChangeEvent e = (TrackManager.LimitChangeEvent)TrackManager.CurrentTrack.Elements[i].Events[j];
										if (e.NextSpeedLimit < spd) {
											double d = stp + e.TrackPositionDelta - Position;
											if (d > 0.0) {
												double s = Math.Sqrt(2.0 * Deceleration * d + e.NextSpeedLimit * e.NextSpeedLimit);
												if (s >= 36.1111111111111) {
													s = double.PositiveInfinity;
												} else if (s >= 33.3333333333333) {
													s = 33.3333333333333;
												} else if (s >= 30.5555555555555) {
													s = 30.5555555555555;
												} else if (s >= 27.7777777777777) {
													s = 27.7777777777777;
												} else if (s >= 25.0000000000000) {
													s = 25.0000000000000;
												} else if (s >= 20.8333333333333) {
													s = 20.8333333333333;
												} else if (s >= 18.0555555555555) {
													s = 18.0555555555555;
												} else if (s >= 15.2777777777777) {
													s = 15.2777777777777;
												} else if (s >= 12.5000000000000) {
													s = 12.5000000000000;
												} else if (s >= 6.94444444444444) {
													s = 6.94444444444444;
												} else if (s >= 4.16666666666666) {
													s = 4.16666666666666;
												} else {
													s = 0.0;
												}
												if (s < e.NextSpeedLimit) s = e.NextSpeedLimit;
												if (s < spd - 0.01) spd = s;
											}
										}
										limit = true;
									} else if (TrackManager.CurrentTrack.Elements[i].Events[j] is TrackManager.StationEndEvent) {
										TrackManager.StationEndEvent e = (TrackManager.StationEndEvent)TrackManager.CurrentTrack.Elements[i].Events[j];
										if (Game.Stations[e.StationIndex].SecuritySystem == Game.SecuritySystem.Ats) {
											double d = stp + e.TrackPositionDelta - Position;
											double s = Math.Sqrt(2.0 * Deceleration * d);
											if (s >= 36.1111111111111) {
												s = double.PositiveInfinity;
											} else if (s >= 33.3333333333333) {
												s = 33.3333333333333;
											} else if (s >= 30.5555555555555) {
												s = 30.5555555555555;
											} else if (s >= 27.7777777777777) {
												s = 27.7777777777777;
											} else if (s >= 25.0000000000000) {
												s = 25.0000000000000;
											} else if (s >= 20.8333333333333) {
												s = 20.8333333333333;
											} else if (s >= 18.0555555555555) {
												s = 18.0555555555555;
											} else if (s >= 15.2777777777777) {
												s = 15.2777777777777;
											} else if (s >= 12.5000000000000) {
												s = 12.5000000000000;
											} else if (s >= 6.94444444444444) {
												s = 6.94444444444444;
											} else if (s >= 4.16666666666666) {
												s = 4.16666666666666;
											} else {
												s = 0.0;
											}
											if (s < spd - 0.01) spd = s;
										}
									}
								} if (j < TrackManager.CurrentTrack.Elements[i].Events.Length) break;
							}
						}
						// previous train
						for (int i = 0; i < Trains.Length; i++) {
							if (i != Train.TrainIndex & !Trains[i].Disposed) {
								double t1 = 100.0 * Math.Floor(0.01 * Trains[i].Cars[Trains[i].Cars.Length - 1].RearAxle.Follower.TrackPosition);
								double t0 = 100.0 * Math.Ceiling(0.01 * Trains[Train.TrainIndex].Cars[0].FrontAxle.Follower.TrackPosition);
								double d = t1 - t0;
								if (d > 0.0) {
									d -= 50.0;
									if (d <= 0.0) {
										spd = 0.0;
									} else {
										double s = 0.85 * Math.Sqrt(d);
										if (s >= 36.1111111111111) {
											s = double.PositiveInfinity;
										} else if (s >= 33.3333333333333) {
											s = 33.3333333333333;
										} else if (s >= 30.5555555555555) {
											s = 30.5555555555555;
										} else if (s >= 27.7777777777777) {
											s = 27.7777777777777;
										} else if (s >= 25.0000000000000) {
											s = 25.0000000000000;
										} else if (s >= 20.8333333333333) {
											s = 20.8333333333333;
										} else if (s >= 18.0555555555555) {
											s = 18.0555555555555;
										} else if (s >= 15.2777777777777) {
											s = 15.2777777777777;
										} else if (s >= 12.5000000000000) {
											s = 12.5000000000000;
										} else if (s >= 6.94444444444444) {
											s = 6.94444444444444;
										} else if (s >= 4.16666666666666) {
											s = 4.16666666666666;
										} else {
											s = 0.0;
										}
										if (s < spd - 0.01) spd = s;
									}
								}
							}
						}
						// new speed restriction
						if (Math.Abs(spd - Train.Specs.Security.Atc.SpeedRestriction) > 0.0277777777777778) {
							int snd = Train.Cars[Train.DriverCar].Sounds.Ding.SoundBufferIndex;
							if (snd >= 0) {
								World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ding.Position;
								SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
							}
						}
						Train.Specs.Security.Atc.SpeedRestriction = spd;
						// service
						if (Train.Specs.Security.State == SecurityState.Service) {
							if (Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed <= Train.Specs.Security.Atc.SpeedRestriction & Train.Specs.Security.Atc.SpeedRestriction > 0.0) {
								Train.Specs.Security.State = SecurityState.Normal;
							} else {
								if (spd == 0.0) {
									Train.Specs.CurrentBrakeNotch.Security = Train.Specs.MaximumBrakeNotch;
								} else {
									int n = (int)Math.Ceiling(3.0 * (Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed - spd));
									if (n < Train.Specs.CurrentBrakeNotch.Driver) {
										n = Train.Specs.CurrentBrakeNotch.Driver;
									}
									if (n < 1) n = 1;
									if (n > Train.Specs.MaximumBrakeNotch) {
										n = Train.Specs.MaximumBrakeNotch;
									}
									Train.Specs.CurrentBrakeNotch.Security = n;
								}
								Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
							}
						} else {
							if (Train.Cars[Train.DriverCar].Specs.CurrentPerceivedSpeed >= Train.Specs.Security.Atc.SpeedRestriction + 0.555555555555556 | Train.Specs.Security.Atc.SpeedRestriction == 0.0) {
								Train.Specs.Security.State = SecurityState.Service;
							}
						}
					} else {
						Train.Specs.CurrentEmergencyBrake.Security = true;
					}
				}
				if (Train.Cars[Train.DriverCar].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
					if (Train.Specs.AirBrake.Handle.Security != AirBrakeHandleState.Release) {
						Train.Specs.CurrentPowerNotch.Security = 0;
					}
				} else if (Train.Specs.CurrentBrakeNotch.Security != 0) {
					Train.Specs.CurrentPowerNotch.Security = 0;
				}
				if (Train.Specs.CurrentEmergencyBrake.Security | Train.Specs.CurrentHoldBrake.Actual) {
					Train.Specs.CurrentPowerNotch.Security = 0;
				}
				if (Train.Specs.CurrentEmergencyBrake.Security) {
					Train.Specs.CurrentBrakeNotch.Security = Train.Specs.MaximumBrakeNotch;
					Train.Specs.AirBrake.Handle.Security = AirBrakeHandleState.Service;
				}
				if ((GetDoorsState(Train, true, true) & TrainDoorState.AllClosed) == 0) {
					Train.Specs.CurrentPowerNotch.Security = 0;
				}
			} else {
				// security system deactivated
				Train.Specs.Security.State = SecurityState.Initialization;
				Train.Specs.Security.Ats.Time = Game.SecondsSinceMidnight;
				Train.Specs.Security.Eb.BellState = SecurityState.Normal;
				Train.Specs.Security.Eb.Time = Game.SecondsSinceMidnight;
				Train.Specs.Security.Eb.Reset = false;
				if (Train.Specs.CurrentPowerNotch.Driver > 0) {
					int snd = Train.Cars[Train.DriverCar].Sounds.Ats.SoundBufferIndex;
					if (snd >= 0) {
						if (!SoundManager.IsPlaying(Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex)) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Ats.Position;
							SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
						}
					}
				} else {
					SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Ats.SoundSourceIndex);
				}
				SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex);
				SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.Eb.SoundSourceIndex);
			}
			// clear transponder data
			if (!KeepTransponderData) {
				Train.Specs.Security.RemovePendingTransponder();
			}
		}

		// acknowledge security system
		internal enum AcknowledgementType { Alarm, Chime, Eb, Reset, Override }
		internal static void AcknowledgeSecuritySystem(Train Train, AcknowledgementType Type) {
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) return;
			switch (Type) {
				case AcknowledgementType.Alarm:
					if (Train.Specs.Security.State == SecurityState.Ringing) {
						if (Train.Specs.CurrentPowerNotch.Driver == 0) {
							bool q = false;
							if (Train.Specs.CurrentEmergencyBrake.Driver) {
								q = true;
							} else if (Train.Cars[Train.DriverCar].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
								if (Train.Specs.AirBrake.Handle.Driver == AirBrakeHandleState.Service) q = true;
							} else {
								if (Train.Specs.CurrentBrakeNotch.Driver > 0) q = true;
							}
							if (q) {
								Train.Specs.Security.State = SecurityState.Normal;
								int snd = Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundBufferIndex;
								if (snd >= 0 & Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex < 0) {
									World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.AtsCnt.Position;
									SoundManager.PlaySound(ref Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex, snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, true);
								}
							}
						}
					} break;
				case AcknowledgementType.Chime:
					SoundManager.StopSound(ref Train.Cars[Train.DriverCar].Sounds.AtsCnt.SoundSourceIndex);
					break;
				case AcknowledgementType.Eb:
					Train.Specs.Security.Eb.Reset = true;
					break;
				case AcknowledgementType.Reset:
					if (Train.Specs.Security.Mode == SecuritySystem.AtsP) {
						bool q = false;
						if (Train.Cars[Train.DriverCar].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
							q = Train.Specs.CurrentReverser.Driver == 0 & Train.Specs.CurrentPowerNotch.Driver == 0 & (Train.Specs.AirBrake.Handle.Driver == AirBrakeHandleState.Service | Train.Specs.CurrentEmergencyBrake.Driver) & !Train.Specs.CurrentHoldBrake.Driver;
						} else {
							q = Train.Specs.CurrentReverser.Driver == 0 & Train.Specs.CurrentPowerNotch.Driver == 0 & (Train.Specs.CurrentBrakeNotch.Driver == Train.Specs.MaximumBrakeNotch | Train.Specs.CurrentEmergencyBrake.Driver) & !Train.Specs.CurrentHoldBrake.Driver;
						}
						if (q) {
							Train.Specs.Security.Ats.AtsPDistance = double.PositiveInfinity;
						}
					} break;
				case AcknowledgementType.Override:
					if (Train.Specs.Security.Mode == SecuritySystem.AtsP & Train.Specs.Security.Ats.AtsPOverrideTime == double.NegativeInfinity) {
						Train.Specs.Security.Ats.AtsPOverrideTime = Game.SecondsSinceMidnight;
					} break;
			}
		}

		// update brake system
		private static void UpdateBrakeSystem(Train Train, double TimeElapsed, out double[] DecelerationDueToBrake, out double[] DecelerationDueToMotor) {
			// individual brake systems
			DecelerationDueToBrake = new double[Train.Cars.Length];
			DecelerationDueToMotor = new double[Train.Cars.Length];
			for (int i = 0; i < Train.Cars.Length; i++) {
				UpdateBrakeSystem(Train, i, TimeElapsed, out DecelerationDueToBrake[i], out DecelerationDueToMotor[i]);
			}

			//// brake pipe pressure distribution
			//double[] NewBrakePipePressure = new double[Train.Cars.Length];
			//for (int i = 0; i < Train.Cars.Length; i++) {
			//    NewBrakePipePressure[i] = Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure;
			//}
			//for (int i = 0; i < Train.Cars.Length; i++) {
			//    if (Train.Cars[i].Specs.BrakeType == CarBrakeType.AutomaticAirBrake | Train.Cars[i].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) {
			//        // to the front car
			//        if (i > 0) {
			//            int j = i - 1;
			//            if (Train.Cars[j].Specs.BrakeType == CarBrakeType.AutomaticAirBrake | Train.Cars[j].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) {
			//                if (Train.Cars[i].Derailed | Train.Cars[j].Derailed) {
			//                    /// brake pipe leak
			//                    double r = Game.BrakePipeLeakRate * TimeElapsed;
			//                    NewBrakePipePressure[i] -= r;
			//                } else {
			//                    /// normal brake pipe connection
			//                    double d = Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[j].Specs.AirBrake.BrakePipeCurrentPressure;
			//                    if (d > 0.0) {
			//                        double s = 0.5 * (Train.Cars[i].Length + Train.Cars[j].Length);
			//                        double r = Train.Cars[j].Specs.AirBrake.BrakePipeFlowSpeed / (s + 0.01) * TimeElapsed;
			//                        if (r > d) r = d;
			//                        if (r > Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure) r = Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure;
			//                        NewBrakePipePressure[i] -= 0.5 * r;
			//                        NewBrakePipePressure[j] += 0.5 * r;
			//                    }
			//                }
			//            }
			//        }
			//        // to the rear car
			//        if (i < Train.Cars.Length - 1) {
			//            int j = i + 1;
			//            if (Train.Cars[j].Specs.BrakeType == CarBrakeType.AutomaticAirBrake | Train.Cars[j].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) {
			//                if (Train.Cars[i].Derailed | Train.Cars[j].Derailed) {
			//                    /// brake pipe leak
			//                    double r = Game.BrakePipeLeakRate * TimeElapsed;
			//                    NewBrakePipePressure[i] -= r;
			//                } else {
			//                    /// normal brake pipe connection
			//                    double d = Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[j].Specs.AirBrake.BrakePipeCurrentPressure;
			//                    if (d > 0.0) {
			//                        double s = 0.5 * (Train.Cars[i].Length + Train.Cars[j].Length);
			//                        double r = Train.Cars[j].Specs.AirBrake.BrakePipeFlowSpeed / (s + 0.01) * TimeElapsed;
			//                        if (r > d) r = d;
			//                        if (r > Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure) r = Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure;
			//                        NewBrakePipePressure[i] -= 0.5 * r;
			//                        NewBrakePipePressure[j] += 0.5 * r;
			//                    }
			//                }
			//            }
			//        }
			//    } else {
			//        NewBrakePipePressure[i] = 0.0;
			//    }
			//}
			//// apply
			//for (int i = 0; i < Train.Cars.Length; i++) {
			//    if (NewBrakePipePressure[i] < 0.0) NewBrakePipePressure[i] = 0.0;
			//    Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure = NewBrakePipePressure[i];
			//}

			// brake pipe pressure distribution dummy
			double TotalPressure = 0.0;
			for (int i = 0; i < Train.Cars.Length; i++) {
				if (i > 0) {
					if (Train.Cars[i - 1].Derailed | Train.Cars[i].Derailed) {
						Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure -= Game.BrakePipeLeakRate * TimeElapsed;
						if (Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure < 0.0) Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure = 0.0;
					}
				}
				if (i < Train.Cars.Length - 1) {
					if (Train.Cars[i].Derailed | Train.Cars[i + 1].Derailed) {
						Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure -= Game.BrakePipeLeakRate * TimeElapsed;
						if (Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure < 0.0) Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure = 0.0;
					}
				}
				TotalPressure += Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure;
			}
			double AveragePressure = TotalPressure / (double)Train.Cars.Length;
			for (int i = 0; i < Train.Cars.Length; i++) {
				Train.Cars[i].Specs.AirBrake.BrakePipeCurrentPressure = AveragePressure;
			}
		}
		private static void UpdateBrakeSystem(Train Train, int CarIndex, double TimeElapsed, out double DecelerationDueToBrake, out double DecelerationDueToMotor) {
			// air compressor
			if (Train.Cars[CarIndex].Specs.AirBrake.Type == AirBrakeType.Main) {
				if (Train.Cars[CarIndex].Specs.AirBrake.AirCompressorEnabled) {
					if (Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure > Train.Cars[CarIndex].Specs.AirBrake.AirCompressorMaximumPressure) {
						Train.Cars[CarIndex].Specs.AirBrake.AirCompressorEnabled = false;
						Train.Cars[CarIndex].Sounds.CpLoopStarted = false;
						/// sound
						int snd = Train.Cars[CarIndex].Sounds.CpEnd.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[CarIndex].Sounds.CpEnd.Position;
							SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
						}
						snd = Train.Cars[CarIndex].Sounds.CpLoop.SoundBufferIndex;
						if (snd >= 0) {
							SoundManager.StopSound(ref Train.Cars[CarIndex].Sounds.CpLoop.SoundSourceIndex);
						}
					} else {
						Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure += Train.Cars[CarIndex].Specs.AirBrake.AirCompressorRate * TimeElapsed;
						/// sound
						if (!Train.Cars[CarIndex].Sounds.CpLoopStarted && Game.SecondsSinceMidnight > Train.Cars[CarIndex].Sounds.CpStartTimeStarted + 5.0) {
							Train.Cars[CarIndex].Sounds.CpLoopStarted = true;
							int snd = Train.Cars[CarIndex].Sounds.CpLoop.SoundBufferIndex;
							if (snd >= 0) {
								World.Vector3D pos = Train.Cars[CarIndex].Sounds.CpLoop.Position;
								SoundManager.PlaySound(ref Train.Cars[CarIndex].Sounds.CpLoop.SoundSourceIndex, snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, true);
							}
						}
					}
				} else {
					if (Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure < Train.Cars[CarIndex].Specs.AirBrake.AirCompressorMinimumPressure) {
						Train.Cars[CarIndex].Specs.AirBrake.AirCompressorEnabled = true;
						/// sound
						Train.Cars[CarIndex].Sounds.CpStartTimeStarted = Game.SecondsSinceMidnight;
						int snd = Train.Cars[CarIndex].Sounds.CpStart.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[CarIndex].Sounds.CpStart.Position;
							SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
						}
					}
				}
			}
			// initialize
			const double Tolerance = 5000.0;
			int airsound = -1;
			// equalizing reservoir
			if (Train.Cars[CarIndex].Specs.AirBrake.Type == AirBrakeType.Main) {
				if (Train.Specs.CurrentEmergencyBrake.Actual) {
					double r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirEmergencyRate;
					double d = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure) r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
					Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure -= r;
				} else {
					if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
						/// automatic air brake
						if (Train.Specs.AirBrake.Handle.Actual == AirBrakeHandleState.Service) {
							double r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirServiceRate;
							double d = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
							double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
							r = GetRate(d / m, r * TimeElapsed);
							if (r > Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure) r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
							Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure -= r;
						} else if (Train.Specs.AirBrake.Handle.Actual == AirBrakeHandleState.Release) {
							double r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirChargeRate;
							double d = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure - Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
							double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
							r = GetRate(d / m, r * TimeElapsed);
							if (r > d) r = d;
							d = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
							if (r > d) r = d;
							double f = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirEqualizingReservoirCoefficient;
							double s = r * f * TimeElapsed;
							if (s > Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure) {
								r *= Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure / s;
								s = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure;
							}
							Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure += 0.5 * r;
							Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure -= 0.5 * s;
						}
					} else if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) {
						/// electromagnetic straight air brake
						double r = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirChargeRate;
						double d = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure - Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
						r = GetRate(d / m, r * TimeElapsed);
						if (r > d) r = d;
						d = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
						if (r > d) r = d;
						double f = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirEqualizingReservoirCoefficient;
						double s = r * f * TimeElapsed;
						if (s > Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure) {
							r *= Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure / s;
							s = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure;
						}
						Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure += 0.5 * r;
						Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure -= 0.5 * s;
					}
				}
			}
			// brake pipe (main reservoir)
			if ((Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.AutomaticAirBrake | Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) & Train.Cars[CarIndex].Specs.AirBrake.Type == AirBrakeType.Main) {
				if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure > Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure + Tolerance) {
					/// brake pipe exhaust valve
					double r = Train.Specs.CurrentEmergencyBrake.Actual ? Train.Cars[CarIndex].Specs.AirBrake.BrakePipeEmergencyRate : Train.Cars[CarIndex].Specs.AirBrake.BrakePipeServiceRate;
					double d = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
					r = (0.5 + 1.5 * d / m) * r * TimeElapsed;
					if (r > d) r = d;
					Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure -= r;
				} else if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure) {
					/// fill brake pipe from main reservoir
					double r = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeChargeRate;
					double d = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.EqualizingReservoirNormalPressure;
					r = (0.5 + 1.5 * d / m) * r * TimeElapsed;
					if (r > d) r = d;
					d = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeNormalPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
					if (r > d) r = d;
					double f = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirBrakePipeCoefficient;
					double s = r * f;
					if (s > Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure) {
						r *= Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure / s;
						s = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure;
					}
					Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure += 0.5 * r;
					Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure -= 0.5 * s;
				}
			}
			// triple valve (auxillary reservoir, brake pipe, brake cylinder)
			if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
				if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure) {
					if (Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure) {
						/// back-flow from brake cylinder to auxillary reservoir
						double u = (Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure - Tolerance) / Tolerance;
						if (u > 1.0) u = 1.0;
						double f = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakeCylinderCoefficient;
						double r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceChargeRate * f;
						double d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure;
						r = GetRate(d * u / m, r * TimeElapsed);
						if (Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure + r > m) {
							r = m - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						}
						if (r > d) r = d;
						double s = r / f;
						if (s > d) {
							r *= d / s;
							s = d;
						}
						if (s > Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure) {
							r *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure / s;
							s = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						}
						Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure += 0.5 * r;
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure -= 0.5 * s;
					} else if (Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure > Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure + Tolerance) {
						/// refill brake cylinder from auxillary reservoir
						double u = (Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure - Tolerance) / Tolerance;
						if (u > 1.0) u = 1.0;
						double f = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakeCylinderCoefficient;
						double r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceChargeRate * f;
						double d = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure;
						r = GetRate(d * u / m, r * TimeElapsed);
						if (r > Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure) {
							r = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						}
						if (r > d) r = d;
						double s = r / f;
						if (s > d) {
							r *= d / s;
							s = d;
						}
						d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						if (s > d) {
							r *= d / s;
							s = d;
						}
						Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure -= 0.5 * r;
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure += 0.5 * s;
					}
					/// air sound
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				} else if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure > Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure + Tolerance) {
					double u = (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure - Tolerance) / Tolerance;
					if (u > 1.0) u = 1.0;
					{ /// refill auxillary reservoir from brake pipe
						double r = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirChargeRate;
						double d = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure;
						r = GetRate(d * u / m, r * TimeElapsed);
						if (r > Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure) {
							r = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
						}
						if (r > d) r = d;
						d = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						if (r > d) r = d;
						double f = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakePipeCoefficient;
						double s = r / f;
						if (s > Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure) {
							r *= Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure / s;
							s = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
						}
						if (s > d) {
							r *= d / s;
							s = d;
						}
						Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure += 0.5 * r;
						Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure -= 0.5 * s;
					}
					{ /// brake cylinder release
						double r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderReleaseRate;
						double d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
						r = GetRate(d * u / m, r * TimeElapsed);
						if (r > Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure) r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure -= r;
						/// air sound
						if (r > 0.0 & Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure < Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure) {
							double p = 0.8 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure - 0.2 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
							if (p < 0.0) p = 0.0;
							Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = p;
							airsound = p < Tolerance ? 0 : Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure > m - Tolerance ? 2 : 1;
						}
					}
				} else {
					/// air sound
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				}
			}
			// solenoid valve for electromagnetic straight air brake (auxillary reservoir, electric command, brake cylinder)
			if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake) {
				/// refill auxillary reservoir from brake pipe
				if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure > Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure + Tolerance) {
					double r = 2.0 * Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirChargeRate;
					double d = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure) {
						r = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
					}
					if (r > d) r = d;
					d = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirMaximumPressure - Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
					if (r > d) r = d;
					double f = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakePipeCoefficient;
					double s = r / f;
					if (s > Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure) {
						r *= Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure / s;
						s = Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure;
					}
					if (s > d) {
						r *= d / s;
						s = d;
					}
					Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure += 0.5 * r;
					Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure -= 0.5 * s;
				}
				{ /// electric command
					bool emergency;
					if (Train.Cars[CarIndex].Specs.AirBrake.BrakePipeCurrentPressure + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure) {
						emergency = true;
					} else {
						emergency = Train.Specs.CurrentEmergencyBrake.Actual;
					}
					double p; if (emergency) {
						p = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					} else {
						p = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
						p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
					}
					if (Train.Cars[CarIndex].Specs.IsMotorCar & !Train.Specs.CurrentEmergencyBrake.Actual & Train.Specs.CurrentReverser.Actual != 0) {
						/// brake control system
						if (Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed) > Train.Cars[CarIndex].Specs.BrakeControlSpeed) {
							if (Train.Cars[CarIndex].Specs.ElectropneumaticType == EletropneumaticBrakeType.ClosingElectromagneticValve) {
								/// closing electromagnetic valve (lock-out valve)
								p = 0.0;
							} else if (Train.Cars[CarIndex].Specs.ElectropneumaticType == EletropneumaticBrakeType.DelayFillingControl) {
								/// delay-filling control
								double f = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
								double a = Train.Cars[CarIndex].Specs.MotorDeceleration;
								double pr = p / Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
								double b = pr * Train.Cars[CarIndex].Specs.BrakeDecelerationAtServiceMaximumPressure;
								double d = b - a;
								if (d > 0.0) {
									p = d / Train.Cars[CarIndex].Specs.BrakeDecelerationAtServiceMaximumPressure;
									if (p > 1.0) p = 1.0;
									p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
								} else {
									p = 0.0;
								}
							}
						}
					}
					if (Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure > p + Tolerance) {
						/// brake cylinder release
						double r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderReleaseRate;
						double d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure - p;
						double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
						r = GetRate(d / m, r * TimeElapsed);
						if (r > Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure) r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						if (r > d) r = d;
						/// air sound
						if (r > 0.0 & Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure < Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure) {
							Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = p;
							airsound = p < Tolerance ? 0 : Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure > m - Tolerance ? 2 : 1;
						}
						/// pressure change
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure -= r;
					} else if (Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure + Tolerance < p) {
						/// refill brake cylinder from auxillary reservoir
						double f = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakeCylinderCoefficient;
						double r;
						if (emergency) {
							r = 2.0 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyChargeRate * f;
						} else {
							r = 2.0 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceChargeRate * f;
						}
						double d = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
						r = GetRate(d / m, r * TimeElapsed);
						if (r > Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure) {
							r = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure;
						}
						if (r > d) r = d;
						double s = r / f;
						if (s > d) {
							r *= d / s;
							s = d;
						}
						d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
						if (s > d) {
							r *= d / s;
							s = d;
						}
						Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirCurrentPressure -= 0.5 * r;
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure += 0.5 * s;
						/// air sound
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					} else {
						/// air sound
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					}
				}
			}
			// valves for electric command brake (main reservoir, electric command, brake cylinder)
			if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectricCommandBrake) {
				double p; if (Train.Specs.CurrentEmergencyBrake.Actual) {
					p = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				} else {
					p = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
					p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
				}
				if (!Train.Specs.CurrentEmergencyBrake.Actual & Train.Specs.CurrentReverser.Actual != 0) {
					/// brake control system
					if (Train.Cars[CarIndex].Specs.IsMotorCar & Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed) > Train.Cars[CarIndex].Specs.BrakeControlSpeed) {
						if (Train.Cars[CarIndex].Specs.ElectropneumaticType == EletropneumaticBrakeType.ClosingElectromagneticValve) {
							/// closing electromagnetic valve (lock-out valve)
							p = 0.0;
						} else if (Train.Cars[CarIndex].Specs.ElectropneumaticType == EletropneumaticBrakeType.DelayFillingControl) {
							/// delay-filling control
							double f = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
							double a = Train.Cars[CarIndex].Specs.MotorDeceleration;
							double pr = p / Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
							double b = pr * Train.Cars[CarIndex].Specs.BrakeDecelerationAtServiceMaximumPressure;
							double d = b - a;
							if (d > 0.0) {
								p = d / Train.Cars[CarIndex].Specs.BrakeDecelerationAtServiceMaximumPressure;
								if (p > 1.0) p = 1.0;
								p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
							} else {
								p = 0.0;
							}
						}
					}
				}
				if (Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure > p + Tolerance | p == 0.0) {
					/// brake cylinder exhaust valve
					double r = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderReleaseRate;
					double d = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > d) r = d;
					/// air sound
					if (r > 0.0 & Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure < Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure) {
						Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = p;
						airsound = p < Tolerance ? 0 : Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure > m - Tolerance ? 2 : 1;
					}
					/// pressure change
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure -= r;
				} else if ((Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure + Tolerance < p | p == Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure) & Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure) {
					/// fill brake cylinder from main reservoir
					double r;
					if (Train.Specs.CurrentEmergencyBrake.Actual) {
						r = 2.0 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyChargeRate;
					} else {
						r = 2.0 * Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceChargeRate;
					}
					double pm = p < Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure ? p : Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure;
					double d = pm - Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > d) r = d;
					double f1 = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakeCylinderCoefficient;
					double f2 = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirBrakePipeCoefficient;
					double f3 = Train.Cars[CarIndex].Specs.AirBrake.AuxillaryReservoirBrakePipeCoefficient;
					double f = f1 * f2 / f3; /// MainReservoirBrakeCylinderCoefficient
					double s = r * f;
					if (s > Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure) {
						r *= Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure / s;
						s = Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure;
					}
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure += 0.5 * r;
					Train.Cars[CarIndex].Specs.AirBrake.MainReservoirCurrentPressure -= 0.5 * s;
					/// air sound
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				} else {
					/// air sound
					Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderSoundPlayedForPressure = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				}
			}
			// straight air pipe (for compatibility needle only)
			if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectromagneticStraightAirBrake & Train.Cars[CarIndex].Specs.AirBrake.Type == AirBrakeType.Main) {
				double p; if (Train.Specs.CurrentEmergencyBrake.Actual) {
					p = 0.0;
				} else {
					p = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
					p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
				}
				if (p + Tolerance < Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure) {
					double r;
					if (Train.Specs.CurrentEmergencyBrake.Actual) {
						r = Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeEmergencyRate;
					} else {
						r = Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeReleaseRate;
					}
					double d = Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure - p;
					double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > d) r = d;
					Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure -= r;
				} else if (p > Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure + Tolerance) {
					double r = Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeServiceRate;
					double d = p - Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure;
					double m = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
					r = GetRate(d / m, r * TimeElapsed);
					if (r > d) r = d;
					Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure += r;
				}
			} else if (Train.Cars[CarIndex].Specs.BrakeType == CarBrakeType.ElectricCommandBrake) {
				double p; if (Train.Specs.CurrentEmergencyBrake.Actual) {
					p = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderEmergencyMaximumPressure;
				} else {
					p = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
					p *= Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
				}
				Train.Cars[CarIndex].Specs.AirBrake.StraightAirPipeCurrentPressure = p;
			}
			// air sound
			if (airsound == 0) {
				/// air zero
				int snd = Train.Cars[CarIndex].Sounds.AirZero.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[CarIndex].Sounds.AirZero.Position;
					SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
				}
			} else if (airsound == 1) {
				/// air
				int snd = Train.Cars[CarIndex].Sounds.Air.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[CarIndex].Sounds.Air.Position;
					SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
				}
			} else if (airsound == 2) {
				/// air high
				int snd = Train.Cars[CarIndex].Sounds.AirHigh.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[CarIndex].Sounds.AirHigh.Position;
					SoundManager.PlaySound(snd, Train, CarIndex, pos, SoundManager.Importance.DontCare, false);
				}
			}
			// deceleration provided by brake
			double pressureratio = Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderCurrentPressure / Train.Cars[CarIndex].Specs.AirBrake.BrakeCylinderServiceMaximumPressure;
			DecelerationDueToBrake = pressureratio * Train.Cars[CarIndex].Specs.BrakeDecelerationAtServiceMaximumPressure;
			// deceleration provided by motor
			if (Train.Cars[CarIndex].Specs.BrakeType != CarBrakeType.AutomaticAirBrake && Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed) >= Train.Cars[CarIndex].Specs.BrakeControlSpeed & Train.Specs.CurrentReverser.Actual != 0 & !Train.Specs.CurrentEmergencyBrake.Actual) {
				double f = (double)Train.Specs.CurrentBrakeNotch.Actual / (double)Train.Specs.MaximumBrakeNotch;
				double a = Train.Cars[CarIndex].Specs.MotorDeceleration;
				DecelerationDueToMotor = f * a;
			} else {
				DecelerationDueToMotor = 0.0;
			}
			// hold brake
			if (Train.Specs.CurrentHoldBrake.Actual & DecelerationDueToMotor == 0.0) {
				if (Game.SecondsSinceMidnight >= Train.Cars[CarIndex].Specs.HoldBrake.NextUpdateTime) {
					Train.Cars[CarIndex].Specs.HoldBrake.NextUpdateTime = Game.SecondsSinceMidnight + Train.Cars[CarIndex].Specs.HoldBrake.UpdateInterval;
					Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput += 0.8 * Train.Cars[CarIndex].Specs.CurrentAcceleration * (double)Math.Sign(Train.Cars[CarIndex].Specs.CurrentPerceivedSpeed);
					if (Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput < 0.0) Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput = 0.0;
					double a = Train.Cars[CarIndex].Specs.MotorDeceleration;
					if (Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput > a) Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput = a;
				}
				DecelerationDueToMotor = Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput;
			} else {
				Train.Cars[CarIndex].Specs.HoldBrake.CurrentAccelerationOutput = 0.0;
			}
			{ // rub sound
				int snd = Train.Cars[CarIndex].Sounds.Rub.SoundBufferIndex;
				if (snd >= 0) {
					double spd = Math.Abs(Train.Cars[CarIndex].Specs.CurrentSpeed);
					double pitch = 1.0 / (spd + 1.0) + 1.0;
					double gain = Train.Cars[CarIndex].Derailed ? 0.0 : pressureratio;
					if (spd < 1.38888888888889) {
						double t = spd * spd;
						gain *= 1.5552 * t - 0.746496 * spd * t;
					} else if (spd > 12.5) {
						double t = spd - 12.5;
						const double fadefactor = 0.1;
						gain *= 1.0 / (fadefactor * t * t + 1.0);
					}
					if (Train.Cars[CarIndex].Sounds.Rub.SoundSourceIndex >= 0) {
						if (pitch > 0.01 & gain > 0.001) {
							SoundManager.ModulateSound(Train.Cars[CarIndex].Sounds.Rub.SoundSourceIndex, pitch, gain);
						} else {
							SoundManager.StopSound(ref Train.Cars[CarIndex].Sounds.Rub.SoundSourceIndex);
						}
					} else if (pitch > 0.02 & gain > 0.01) {
						SoundManager.PlaySound(ref Train.Cars[CarIndex].Sounds.Rub.SoundSourceIndex, snd, Train, CarIndex, Train.Cars[CarIndex].Sounds.Rub.Position, SoundManager.Importance.DontCare, true, pitch, gain);
					}
				}
			}
		}
		private static double GetRate(double Ratio, double Factor) {
			Ratio = Ratio < 0.0 ? 0.0 : Ratio > 1.0 ? 1.0 : Ratio;
			Ratio = 1.0 - Ratio;
			return 1.5 * Factor * (1.01 - Ratio * Ratio);
		}

		// apply emergency brake
		internal static void ApplyEmergencyBrake(Train Train) {
			// sound
			if (!Train.Specs.CurrentEmergencyBrake.Driver) {
				int snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMax.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMax.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
				for (int i = 0; i < Train.Cars.Length; i++) {
					snd = Train.Cars[i].Sounds.EmrBrake.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[i].Sounds.EmrBrake.Position;
						SoundManager.PlaySound(snd, Train, i, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
			// apply
			if (Train.Specs.SingleHandle) {
				ApplyNotch(Train, 0, false, Train.Specs.MaximumBrakeNotch, true);
			} else {
				ApplyNotch(Train, 0, true, Train.Specs.MaximumBrakeNotch, true);
			}
			ApplyAirBrakeHandle(Train, AirBrakeHandleState.Service);
			Train.Specs.CurrentEmergencyBrake.Driver = true;
			Train.Specs.CurrentHoldBrake.Driver = false;
			Train.Specs.CurrentConstSpeed = false;
			Train.Specs.Security.Eb.Reset = true;
			// plugin
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
				PluginManager.UpdatePower(Train);
				PluginManager.UpdateBrake(Train);
			}
		}

		// unapply emergency brake
		internal static void UnapplyEmergencyBrake(Train Train) {
			if (Train.Specs.CurrentEmergencyBrake.Driver) {
				// sound
				int snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
				// apply
				if (Train.Specs.SingleHandle) {
					ApplyNotch(Train, 0, false, Train.Specs.MaximumBrakeNotch, true);
				} else {
					ApplyNotch(Train, 0, true, Train.Specs.MaximumBrakeNotch, true);
				}
				ApplyAirBrakeHandle(Train, AirBrakeHandleState.Service);
				Train.Specs.CurrentEmergencyBrake.Driver = false;
				Train.Specs.Security.Eb.Reset = true;
				// plugin
				if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
					PluginManager.UpdatePower(Train);
					PluginManager.UpdateBrake(Train);
				}
			}
		}

		// apply hold brake
		internal static void ApplyHoldBrake(Train Train, bool Value) {
			Train.Specs.CurrentHoldBrake.Driver = Value;
			// plugin
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
				PluginManager.UpdatePower(Train);
				PluginManager.UpdateBrake(Train);
			}
		}

		// apply reverser
		internal static void ApplyReverser(Train Train, int Value, bool Relative) {
			int a = Train.Specs.CurrentReverser.Driver;
			int r = Relative ? a + Value : Value;
			if (r < -1) r = -1;
			if (r > 1) r = 1;
			Train.Specs.CurrentReverser.Driver = r;
			// plugin
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
				PluginManager.UpdateReverser(Train);
			}
			Game.AddBlackBoxEntry(Game.BlackBoxEventToken.None);
			// sound
			if (a == 0 & r != 0) {
				int snd = Train.Cars[Train.DriverCar].Sounds.ReverserOn.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.ReverserOn.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
			} else if (a != 0 & r == 0) {
				int snd = Train.Cars[Train.DriverCar].Sounds.ReverserOff.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.ReverserOff.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
			}
		}

		// apply notch
		internal static void ApplyNotch(Train Train, int PowerValue, bool PowerRelative, int BrakeValue, bool BrakeRelative) {
			// determine notch
			int p = PowerRelative ? PowerValue + Train.Specs.CurrentPowerNotch.Driver : PowerValue;
			if (p < 0) {
				p = 0;
			} else if (p > Train.Specs.MaximumPowerNotch) {
				p = Train.Specs.MaximumPowerNotch;
			}
			int b = BrakeRelative ? BrakeValue + Train.Specs.CurrentBrakeNotch.Driver : BrakeValue;
			if (b < 0) {
				b = 0;
			} else if (b > Train.Specs.MaximumBrakeNotch) {
				b = Train.Specs.MaximumBrakeNotch;
			}
			if (!BrakeRelative) {
				Train.Specs.CurrentEmergencyBrake.Driver = false;
			}
			if (p != Train.Specs.CurrentPowerNotch.Driver | b != Train.Specs.CurrentBrakeNotch.Driver) {
				Train.Specs.Security.Eb.Reset = true;
			}
			// power sound
			if (p < Train.Specs.CurrentPowerNotch.Driver) {
				if (p > 0) {
					// down (not min)
					int snd = Train.Cars[Train.DriverCar].Sounds.MasterControllerDown.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.MasterControllerDown.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				} else {
					// min
					int snd = Train.Cars[Train.DriverCar].Sounds.MasterControllerMin.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.MasterControllerMin.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				}
			} else if (p > Train.Specs.CurrentPowerNotch.Driver) {
				if (p < Train.Specs.MaximumPowerNotch) {
					// up (not max)
					int snd = Train.Cars[Train.DriverCar].Sounds.MasterControllerUp.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.MasterControllerUp.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				} else {
					// max
					int snd = Train.Cars[Train.DriverCar].Sounds.MasterControllerMax.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.MasterControllerMax.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				}
			}
			// brake sound
			if (b < Train.Specs.CurrentBrakeNotch.Driver) {
				// brake release
				int snd = Train.Cars[Train.DriverCar].Sounds.Brake.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Brake.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
				if (b > 0) {
					// brake release (not min)
					snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				} else {
					// brake min
					snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMin.SoundBufferIndex;
					if (snd >= 0) {
						World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMin.Position;
						SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
					}
				}
			} else if (b > Train.Specs.CurrentBrakeNotch.Driver) {
				// brake
				int snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleApply.SoundBufferIndex;
				if (snd >= 0) {
					World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleApply.Position;
					SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
				}
			}
			// apply notch
			if (Train.Specs.SingleHandle) {
				if (b != 0) p = 0;
			}
			Train.Specs.CurrentPowerNotch.Driver = p;
			Train.Specs.CurrentBrakeNotch.Driver = b;
			Game.AddBlackBoxEntry(Game.BlackBoxEventToken.None);
			// plugin
			if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
				PluginManager.UpdatePower(Train);
				PluginManager.UpdateBrake(Train);
			}
		}

		// apply air brake handle
		internal static void ApplyAirBrakeHandle(Train Train, int RelativeDirection) {
			if (Train.Cars[Train.DriverCar].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
				if (RelativeDirection == -1) {
					if (Train.Specs.AirBrake.Handle.Driver == AirBrakeHandleState.Service) {
						ApplyAirBrakeHandle(Train, AirBrakeHandleState.Lap);
					} else {
						ApplyAirBrakeHandle(Train, AirBrakeHandleState.Release);
					}
				} else if (RelativeDirection == 1) {
					if (Train.Specs.AirBrake.Handle.Driver == AirBrakeHandleState.Release) {
						ApplyAirBrakeHandle(Train, AirBrakeHandleState.Lap);
					} else {
						ApplyAirBrakeHandle(Train, AirBrakeHandleState.Service);
					}
				}
				Game.AddBlackBoxEntry(Game.BlackBoxEventToken.None);
			}
		}
		internal static void ApplyAirBrakeHandle(Train Train, AirBrakeHandleState State) {
			if (Train.Cars[Train.DriverCar].Specs.BrakeType == CarBrakeType.AutomaticAirBrake) {
				if (State != Train.Specs.AirBrake.Handle.Driver) {
					Train.Specs.Security.Eb.Reset = true;
					if (State == AirBrakeHandleState.Service) {
						int snd = Train.Cars[Train.DriverCar].Sounds.Brake.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Brake.Position;
							SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
						}
					}
					// sound
					if ((int)State < (int)Train.Specs.AirBrake.Handle.Driver) {
						// brake release
						int snd = Train.Cars[Train.DriverCar].Sounds.Brake.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.Brake.Position;
							SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
						}
						if ((int)State > 0) {
							// brake release (not min)
							snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.SoundBufferIndex;
							if (snd >= 0) {
								World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleRelease.Position;
								SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
							}
						} else {
							// brake min
							snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMin.SoundBufferIndex;
							if (snd >= 0) {
								World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleMin.Position;
								SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
							}
						}
					} else if ((int)State > (int)Train.Specs.AirBrake.Handle.Driver) {
						// brake
						int snd = Train.Cars[Train.DriverCar].Sounds.BrakeHandleApply.SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[Train.DriverCar].Sounds.BrakeHandleApply.Position;
							SoundManager.PlaySound(snd, Train, Train.DriverCar, pos, SoundManager.Importance.DontCare, false);
						}
					}
					// apply
					Train.Specs.AirBrake.Handle.Driver = State;
					Game.AddBlackBoxEntry(Game.BlackBoxEventToken.None);
					// plugin
					if (Train.Specs.Security.Mode == SecuritySystem.Bve4Plugin) {
						PluginManager.UpdatePower(Train);
						PluginManager.UpdateBrake(Train);
					}
				}
			}
		}

		// update train passengers
		private static void UpdateTrainPassengers(Train Train, double TimeElapsed) {
			const double spdmax = 1.0;
			double jerk = 1.0 / (0.1 + Train.Passengers.PassengerRatio);
			const double acc = 0.15;
			double d = Train.Passengers.CurrentAcceleration - Train.Specs.CurrentAverageAcceleration;
			Train.Passengers.CurrentSpeedDifference += d * TimeElapsed;
			double j = jerk * (1.0 - 2.0 * Math.Abs(Train.Passengers.CurrentSpeedDifference) / spdmax);
			if (Train.Passengers.CurrentSpeedDifference < 0.0) {
				Train.Passengers.CurrentAcceleration += j * TimeElapsed;
			} else if (Train.Passengers.CurrentSpeedDifference > 0.0) {
				Train.Passengers.CurrentAcceleration -= j * TimeElapsed;
			}
			if (Train.Passengers.CurrentSpeedDifference < 0.0) {
				Train.Passengers.CurrentSpeedDifference += acc * TimeElapsed;
				if (Train.Passengers.CurrentSpeedDifference > 0.0) Train.Passengers.CurrentSpeedDifference = 0.0;
			} else if (Train.Passengers.CurrentAcceleration > 0.0) {
				Train.Passengers.CurrentSpeedDifference -= acc * TimeElapsed;
				if (Train.Passengers.CurrentSpeedDifference < 0.0) Train.Passengers.CurrentSpeedDifference = 0.0;
			}
			if (Math.Abs(Train.Passengers.CurrentAcceleration) > 2.0 * spdmax) {
				Train.Passengers.CurrentAcceleration = Train.Specs.CurrentAverageAcceleration;
				Train.Passengers.CurrentSpeedDifference = 0.0;
				Train.Passengers.FallenOver = true;
			} else {
				Train.Passengers.FallenOver = false;
			}
		}

		// update speeds
		private static void UpdateSpeeds(Train Train, double TimeElapsed) {
			if (Game.MinimalisticSimulation & Train == PlayerTrain) {
				// hold the position of the player's train during startup
				for (int i = 0; i < Train.Cars.Length; i++) {
					Train.Cars[i].Specs.CurrentSpeed = 0.0;
					Train.Cars[i].Specs.CurrentAccelerationOutput = 0.0;
				} return;
			}
			// update brake system
			double[] DecelerationDueToBrake, DecelerationDueToMotor;
			UpdateBrakeSystem(Train, TimeElapsed, out DecelerationDueToBrake, out DecelerationDueToMotor);
			// calculate new car speeds
			double[] NewSpeeds = new double[Train.Cars.Length];
			for (int i = 0; i < Train.Cars.Length; i++) {
				double PowerRollingCouplerAcceleration;
				// rolling on an incline
				{
					double a = Train.Cars[i].FrontAxle.Follower.WorldDirection.Y;
					double b = Train.Cars[i].RearAxle.Follower.WorldDirection.Y;
					PowerRollingCouplerAcceleration = -0.5 * (a + b) * Game.RouteAccelerationDueToGravity;
				}
				// friction
				double FrictionBrakeAcceleration;
				{
					double v = Math.Abs(Train.Cars[i].Specs.CurrentSpeed);
					double a = GetResistance(Train, i, ref Train.Cars[i].FrontAxle, v);
					double b = GetResistance(Train, i, ref Train.Cars[i].RearAxle, v);
					FrictionBrakeAcceleration = 0.5 * (a + b);
				}
				// power
				double wheelspin = 0.0;
				double wf = GetCriticalWheelSlipAcceleration(Train, i, Train.Cars[i].FrontAxle.Follower.AdhesionMultiplier, Train.Cars[i].FrontAxle.Follower.WorldUp.Y);
				double wr = GetCriticalWheelSlipAcceleration(Train, i, Train.Cars[i].RearAxle.Follower.AdhesionMultiplier, Train.Cars[i].RearAxle.Follower.WorldUp.Y);
				if (Train.Cars[i].Derailed) wf = 0.0;
				if (Train.Cars[i].Derailed) wr = 0.0;
				if (DecelerationDueToMotor[i] == 0.0) {
					double a;
					if (Train.Cars[i].Specs.IsMotorCar) {
						if (DecelerationDueToMotor[i] == 0.0) {
							if (Train.Specs.CurrentReverser.Actual != 0 & Train.Specs.CurrentPowerNotch.Actual > 0 & !Train.Specs.CurrentHoldBrake.Actual & !Train.Specs.CurrentEmergencyBrake.Actual) {
								/// target acceleration
								a = GetAcceleration(Train, i, Train.Specs.CurrentPowerNotch.Actual - 1, (double)Train.Specs.CurrentReverser.Actual * Train.Cars[i].Specs.CurrentSpeed);
								/// readhesion device
								if (a > Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput) {
									a = Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput;
								}
								/// wheel slip
								if (a < wf) {
									Train.Cars[i].FrontAxle.CurrentWheelSlip = false;
								} else {
									Train.Cars[i].FrontAxle.CurrentWheelSlip = true;
									wheelspin += (double)Train.Specs.CurrentReverser.Actual * a * Train.Cars[i].Specs.Mass;
								}
								if (a < wr) {
									Train.Cars[i].RearAxle.CurrentWheelSlip = false;
								} else {
									Train.Cars[i].RearAxle.CurrentWheelSlip = true;
									wheelspin += (double)Train.Specs.CurrentReverser.Actual * a * Train.Cars[i].Specs.Mass;
								}
								/// readhesion device
								{
									if (Game.SecondsSinceMidnight >= Train.Cars[i].Specs.ReAdhesionDevice.NextUpdateTime) {
										double d = Train.Cars[i].Specs.ReAdhesionDevice.UpdateInterval;
										double f = Train.Cars[i].Specs.ReAdhesionDevice.ApplicationFactor;
										double t = Train.Cars[i].Specs.ReAdhesionDevice.ReleaseInterval;
										double r = Train.Cars[i].Specs.ReAdhesionDevice.ReleaseFactor;
										Train.Cars[i].Specs.ReAdhesionDevice.NextUpdateTime = Game.SecondsSinceMidnight + d;
										if (Train.Cars[i].FrontAxle.CurrentWheelSlip | Train.Cars[i].RearAxle.CurrentWheelSlip) {
											Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput = a * f;
											Train.Cars[i].Specs.ReAdhesionDevice.TimeStable = 0.0;
										} else {
											Train.Cars[i].Specs.ReAdhesionDevice.TimeStable += d;
											if (Train.Cars[i].Specs.ReAdhesionDevice.TimeStable >= t) {
												Train.Cars[i].Specs.ReAdhesionDevice.TimeStable -= t;
												if (r != 0.0 & Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput <= a + 1.0) {
													if (Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput < 0.025) {
														Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput = 0.025;
													} else {
														Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput *= r;
													}
												} else {
													Train.Cars[i].Specs.ReAdhesionDevice.MaximumAccelerationOutput = double.PositiveInfinity;
												}
											}
										}
									}
								}
								/// const speed
								if (Train.Specs.CurrentConstSpeed) {
									if (Game.SecondsSinceMidnight >= Train.Cars[i].Specs.ConstSpeed.NextUpdateTime) {
										Train.Cars[i].Specs.ConstSpeed.NextUpdateTime = Game.SecondsSinceMidnight + Train.Cars[i].Specs.ConstSpeed.UpdateInterval;
										Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput -= 0.8 * Train.Cars[i].Specs.CurrentAcceleration * (double)Train.Specs.CurrentReverser.Actual;
										if (Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput < 0.0) Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput = 0.0;
									}
									if (a > Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput) a = Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput;
									if (a < 0.0) a = 0.0;
								} else {
									Train.Cars[i].Specs.ConstSpeed.CurrentAccelerationOutput = a;
								}
								/// finalize
								if (wheelspin != 0.0) a = 0.0;
							} else {
								a = 0.0;
								Train.Cars[i].FrontAxle.CurrentWheelSlip = false;
								Train.Cars[i].RearAxle.CurrentWheelSlip = false;
							}
						} else {
							a = 0.0;
							Train.Cars[i].FrontAxle.CurrentWheelSlip = false;
							Train.Cars[i].RearAxle.CurrentWheelSlip = false;
						}
					} else {
						a = 0.0;
						Train.Cars[i].FrontAxle.CurrentWheelSlip = false;
						Train.Cars[i].RearAxle.CurrentWheelSlip = false;
					}
					if (!Train.Cars[i].Derailed) {
						if (Train.Cars[i].Specs.CurrentAccelerationOutput < a) {
							if (Train.Cars[i].Specs.CurrentAccelerationOutput < 0.0) {
								Train.Cars[i].Specs.CurrentAccelerationOutput += Train.Cars[i].Specs.JerkBrakeDown * TimeElapsed;
							} else {
								Train.Cars[i].Specs.CurrentAccelerationOutput += Train.Cars[i].Specs.JerkPowerUp * TimeElapsed;
							}
							if (Train.Cars[i].Specs.CurrentAccelerationOutput > a) {
								Train.Cars[i].Specs.CurrentAccelerationOutput = a;
							}
						} else {
							Train.Cars[i].Specs.CurrentAccelerationOutput -= Train.Cars[i].Specs.JerkPowerDown * TimeElapsed;
							if (Train.Cars[i].Specs.CurrentAccelerationOutput < a) {
								Train.Cars[i].Specs.CurrentAccelerationOutput = a;
							}
						}
					} else {
						Train.Cars[i].Specs.CurrentAccelerationOutput = 0.0;
					}
				}
				// brake
				bool wheellock = false;
				if (wheelspin == 0.0 & Train.Cars[i].Derailed) wheellock = true;
				if (!Train.Cars[i].Derailed & wheelspin == 0.0) {
					double a;
					/// motor
					if (Train.Cars[i].Specs.IsMotorCar & DecelerationDueToMotor[i] != 0.0) {
						a = -DecelerationDueToMotor[i];
						if (Train.Cars[i].Specs.CurrentAccelerationOutput > a) {
							if (Train.Cars[i].Specs.CurrentAccelerationOutput > 0.0) {
								Train.Cars[i].Specs.CurrentAccelerationOutput -= Train.Cars[i].Specs.JerkPowerDown * TimeElapsed;
							} else {
								Train.Cars[i].Specs.CurrentAccelerationOutput -= Train.Cars[i].Specs.JerkBrakeUp * TimeElapsed;
							}
							if (Train.Cars[i].Specs.CurrentAccelerationOutput < a) {
								Train.Cars[i].Specs.CurrentAccelerationOutput = a;
							}
						} else {
							Train.Cars[i].Specs.CurrentAccelerationOutput += Train.Cars[i].Specs.JerkBrakeDown * TimeElapsed;
							if (Train.Cars[i].Specs.CurrentAccelerationOutput > a) {
								Train.Cars[i].Specs.CurrentAccelerationOutput = a;
							}
						}
					}
					/// brake
					a = DecelerationDueToBrake[i];
					if (Train.Cars[i].Specs.CurrentSpeed >= -0.01 & Train.Cars[i].Specs.CurrentSpeed <= 0.01) {
						double rf = Train.Cars[i].FrontAxle.Follower.WorldDirection.Y;
						double rr = Train.Cars[i].RearAxle.Follower.WorldDirection.Y;
						double ra = Math.Abs(0.5 * (rf + rr) * Game.RouteAccelerationDueToGravity);
						if (a > ra) a = ra;
					}
					if (a >= wf) {
						wheellock = true;
					} else {
						FrictionBrakeAcceleration += 0.5 * a;
					}
					if (a >= wr) {
						wheellock = true;
					} else {
						FrictionBrakeAcceleration += 0.5 * a;
					}
				} else if (Train.Cars[i].Derailed) {
					FrictionBrakeAcceleration += Game.CoefficientOfGroundFriction * Game.RouteAccelerationDueToGravity;
				}
				// motor
				if (Train.Specs.CurrentReverser.Actual != 0) {
					if (Train.Cars[i].Specs.CurrentAccelerationOutput > 0.0) {
						PowerRollingCouplerAcceleration += (double)Train.Specs.CurrentReverser.Actual * Train.Cars[i].Specs.CurrentAccelerationOutput;
					} else {
						double a = -Train.Cars[i].Specs.CurrentAccelerationOutput;
						if (a >= wf) {
							Train.Cars[i].FrontAxle.CurrentWheelSlip = true;
						} else if (!Train.Cars[i].Derailed) {
							FrictionBrakeAcceleration += 0.5 * a;
						}
						if (a >= wr) {
							Train.Cars[i].RearAxle.CurrentWheelSlip = true;
						} else {
							FrictionBrakeAcceleration += 0.5 * a;
						}
					}
				} else {
					Train.Cars[i].Specs.CurrentAccelerationOutput = 0.0;
				}
				// perceived speed
				{
					double target;
					if (wheellock) {
						target = 0.0;
					} else if (wheelspin == 0.0) {
						target = Train.Cars[i].Specs.CurrentSpeed;
					} else {
						target = Train.Cars[i].Specs.CurrentSpeed + wheelspin / 2500.0;
					}
					double diff = target - Train.Cars[i].Specs.CurrentPerceivedSpeed;
					double rate = (diff < 0.0 ? 5.0 : 1.0) * Game.RouteAccelerationDueToGravity * TimeElapsed;
					rate *= 1.0 - 0.7 / (diff * diff + 1.0);
					double factor = rate * rate;
					factor = 1.0 - factor / (factor + 1000.0);
					rate *= factor;
					if (diff >= -rate & diff <= rate) {
						Train.Cars[i].Specs.CurrentPerceivedSpeed = target;
					} else {
						Train.Cars[i].Specs.CurrentPerceivedSpeed += rate * (double)Math.Sign(diff);
					}
				}
				// perceived traveled distance
				Train.Cars[i].Specs.CurrentPerceivedTraveledDistance += Math.Abs(Train.Cars[i].Specs.CurrentPerceivedSpeed) * TimeElapsed;
				// calculate new speed
				{
					int d = Math.Sign(Train.Cars[i].Specs.CurrentSpeed);
					double a = PowerRollingCouplerAcceleration;
					double b = FrictionBrakeAcceleration;
					if (Math.Abs(a) < b) {
						if (Math.Sign(a) == d) {
							if (d == 0) {
								NewSpeeds[i] = 0.0;
							} else {
								double c = (b - Math.Abs(a)) * TimeElapsed;
								if (Math.Abs(Train.Cars[i].Specs.CurrentSpeed) > c) {
									NewSpeeds[i] = Train.Cars[i].Specs.CurrentSpeed - (double)d * c;
								} else {
									NewSpeeds[i] = 0.0;
								}
							}
						} else {
							double c = (Math.Abs(a) + b) * TimeElapsed;
							if (Math.Abs(Train.Cars[i].Specs.CurrentSpeed) > c) {
								NewSpeeds[i] = Train.Cars[i].Specs.CurrentSpeed - (double)d * c;
							} else {
								NewSpeeds[i] = 0.0;
							}
						}
					} else {
						NewSpeeds[i] = Train.Cars[i].Specs.CurrentSpeed + (a - b * (double)d) * TimeElapsed;
					}
				}
			}
			// calculate center of mass position
			double[] CenterOfCarPositions = new double[Train.Cars.Length];
			double CenterOfMassPosition = 0.0;
			double TrainMass = 0.0;
			for (int i = 0; i < Train.Cars.Length; i++) {
				double pr = Train.Cars[i].RearAxle.Follower.TrackPosition - Train.Cars[i].RearAxlePosition;
				double pf = Train.Cars[i].FrontAxle.Follower.TrackPosition - Train.Cars[i].FrontAxlePosition;
				CenterOfCarPositions[i] = 0.5 * (pr + pf);
				CenterOfMassPosition += CenterOfCarPositions[i] * Train.Cars[i].Specs.Mass;
				TrainMass += Train.Cars[i].Specs.Mass;
			}
			if (TrainMass != 0.0) {
				CenterOfMassPosition /= TrainMass;
			}
			{ // coupler
				/// determine closest cars
				int p = -1; /// primary car index
				int s = -1; /// secondary car index
				{
					double PrimaryDistance = double.MaxValue;
					for (int i = 0; i < Train.Cars.Length; i++) {
						double d = Math.Abs(CenterOfCarPositions[i] - CenterOfMassPosition);
						if (d < PrimaryDistance) {
							PrimaryDistance = d;
							p = i;
						}
					}
					double SecondDistance = double.MaxValue;
					for (int i = p - 1; i <= p + 1; i++) {
						if (i >= 0 & i < Train.Cars.Length & i != p) {
							double d = Math.Abs(CenterOfCarPositions[i] - CenterOfMassPosition);
							if (d < SecondDistance) {
								SecondDistance = d;
								s = i;
							}
						}
					}
					if (s >= 0 && PrimaryDistance <= 0.25 * (PrimaryDistance + SecondDistance)) {
						s = -1;
					}
				}
				/// coupler
				bool[] CouplerCollision = new bool[Train.Couplers.Length];
				int cf, cr;
				if (s >= 0) {
					// use two cars as center of mass
					if (p > s) {
						int t = p; p = s; s = t;
					}
					double min = Train.Couplers[p].MinimumDistanceBetweenCars;
					double max = Train.Couplers[p].MaximumDistanceBetweenCars;
					double d = CenterOfCarPositions[p] - CenterOfCarPositions[s] - 0.5 * (Train.Cars[p].Length + Train.Cars[s].Length);
					if (d < min) {
						double t = (min - d) / (Train.Cars[p].Specs.Mass + Train.Cars[s].Specs.Mass);
						double tp = t * Train.Cars[s].Specs.Mass;
						double ts = t * Train.Cars[p].Specs.Mass;
						TrackManager.UpdateTrackFollower(ref Train.Cars[p].FrontAxle.Follower, Train.Cars[p].FrontAxle.Follower.TrackPosition + tp, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[p].RearAxle.Follower, Train.Cars[p].RearAxle.Follower.TrackPosition + tp, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[s].FrontAxle.Follower, Train.Cars[s].FrontAxle.Follower.TrackPosition - ts, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[s].RearAxle.Follower, Train.Cars[s].RearAxle.Follower.TrackPosition - ts, true, true);
						CenterOfCarPositions[p] += tp;
						CenterOfCarPositions[s] -= ts;
						CouplerCollision[p] = true;
					} else if (d > max & !Train.Cars[p].Derailed & !Train.Cars[s].Derailed) {
						double t = (d - max) / (Train.Cars[p].Specs.Mass + Train.Cars[s].Specs.Mass);
						double tp = t * Train.Cars[s].Specs.Mass;
						double ts = t * Train.Cars[p].Specs.Mass;
						TrackManager.UpdateTrackFollower(ref Train.Cars[p].FrontAxle.Follower, Train.Cars[p].FrontAxle.Follower.TrackPosition - tp, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[p].RearAxle.Follower, Train.Cars[p].RearAxle.Follower.TrackPosition - tp, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[s].FrontAxle.Follower, Train.Cars[s].FrontAxle.Follower.TrackPosition + ts, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[s].RearAxle.Follower, Train.Cars[s].RearAxle.Follower.TrackPosition + ts, true, true);
						CenterOfCarPositions[p] -= tp;
						CenterOfCarPositions[s] += ts;
						CouplerCollision[p] = true;
					}
					cf = p;
					cr = s;
				} else {
					// use one car as center of mass
					cf = p;
					cr = p;
				}
				/// front cars
				for (int i = cf - 1; i >= 0; i--) {
					double min = Train.Couplers[i].MinimumDistanceBetweenCars;
					double max = Train.Couplers[i].MaximumDistanceBetweenCars;
					double d = CenterOfCarPositions[i] - CenterOfCarPositions[i + 1] - 0.5 * (Train.Cars[i].Length + Train.Cars[i + 1].Length);
					if (d < min) {
						double t = min - d + 0.0001;
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].FrontAxle.Follower, Train.Cars[i].FrontAxle.Follower.TrackPosition + t, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].RearAxle.Follower, Train.Cars[i].RearAxle.Follower.TrackPosition + t, true, true);
						CenterOfCarPositions[i] += t;
						CouplerCollision[i] = true;
					} else if (d > max & !Train.Cars[i].Derailed & !Train.Cars[i + 1].Derailed) {
						double t = d - max + 0.0001;
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].FrontAxle.Follower, Train.Cars[i].FrontAxle.Follower.TrackPosition - t, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].RearAxle.Follower, Train.Cars[i].RearAxle.Follower.TrackPosition - t, true, true);
						CenterOfCarPositions[i] -= t;
						CouplerCollision[i] = true;
					}
				}
				/// rear cars
				for (int i = cr + 1; i < Train.Cars.Length; i++) {
					double min = Train.Couplers[i - 1].MinimumDistanceBetweenCars;
					double max = Train.Couplers[i - 1].MaximumDistanceBetweenCars;
					double d = CenterOfCarPositions[i - 1] - CenterOfCarPositions[i] - 0.5 * (Train.Cars[i].Length + Train.Cars[i - 1].Length);
					if (d < min) {
						double t = min - d + 0.0001;
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].FrontAxle.Follower, Train.Cars[i].FrontAxle.Follower.TrackPosition - t, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].RearAxle.Follower, Train.Cars[i].RearAxle.Follower.TrackPosition - t, true, true);
						CenterOfCarPositions[i] -= t;
						CouplerCollision[i - 1] = true;
					} else if (d > max & !Train.Cars[i].Derailed & !Train.Cars[i - 1].Derailed) {
						double t = d - max + 0.0001;
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].FrontAxle.Follower, Train.Cars[i].FrontAxle.Follower.TrackPosition + t, true, true);
						TrackManager.UpdateTrackFollower(ref Train.Cars[i].RearAxle.Follower, Train.Cars[i].RearAxle.Follower.TrackPosition + t, true, true);
						CenterOfCarPositions[i] += t;
						CouplerCollision[i - 1] = true;
					}
				}
				/// update speeds
				for (int i = 0; i < Train.Couplers.Length; i++) {
					if (CouplerCollision[i]) {
						int j; for (j = i + 1; j < Train.Couplers.Length; j++) {
							if (!CouplerCollision[j]) break;
						}
						double v = 0.0;
						double m = 0.0;
						for (int k = i; k <= j; k++) {
							v += NewSpeeds[k] * Train.Cars[k].Specs.Mass;
							m += Train.Cars[k].Specs.Mass;
						}
						if (m != 0.0) {
							v /= m;
						} else {
							throw new System.InvalidOperationException("SHOULD NOT HAVE HAPPENED [#0632] PLEASE REPORT THIS PROBLEM");
						}
						for (int k = i; k <= j; k++) {
							if (Interface.CurrentOptions.Derailments && Math.Abs(v - NewSpeeds[k]) > 0.5 * Game.CriticalCollisionSpeedDifference) {
								Train.Cars[k].Derailed = true;
							}
							NewSpeeds[k] = v;
						}
						i = j - 1;
					}
				}
			}
			// update average data
			Train.Specs.CurrentAverageSpeed = 0.0;
			Train.Specs.CurrentAverageAcceleration = 0.0;
			Train.Specs.CurrentAverageJerk = 0.0;
			double invtime = TimeElapsed != 0.0 ? 1.0 / TimeElapsed : 1.0;
			for (int i = 0; i < Train.Cars.Length; i++) {
				Train.Cars[i].Specs.CurrentAcceleration = (NewSpeeds[i] - Train.Cars[i].Specs.CurrentSpeed) * invtime;
				Train.Cars[i].Specs.CurrentSpeed = NewSpeeds[i];
				Train.Specs.CurrentAverageSpeed += NewSpeeds[i];
				Train.Specs.CurrentAverageAcceleration += Train.Cars[i].Specs.CurrentAcceleration;
			}
			double invcarlen = 1.0 / (double)Train.Cars.Length;
			Train.Specs.CurrentAverageSpeed *= invcarlen;
			Train.Specs.CurrentAverageAcceleration *= invcarlen;
		}

		// update train physics and controls
		private static void UpdateTrainPhysicsAndControls(Train Train, double TimeElapsed) {
			if (TimeElapsed == 0.0) return;
			// move cars
			for (int i = 0; i < Train.Cars.Length; i++) {
				MoveCar(Train, i, Train.Cars[i].Specs.CurrentSpeed * TimeElapsed, TimeElapsed);
			}
			// update cars
			if (!Game.MinimalisticSimulation) {
				for (int i = 0; i < Train.Cars.Length; i++) {
					UpdateCar(Train, i, TimeElapsed);
				}
			}
			// update station and doors
			if (!Game.MinimalisticSimulation | Train != PlayerTrain) {
				UpdateTrainStation(Train, TimeElapsed);
				UpdateTrainDoors(Train, TimeElapsed);
			}
			// update camera
			if (!Game.MinimalisticSimulation & Train == PlayerTrain) {
				if (World.CameraMode == World.CameraViewMode.Interior | World.CameraMode == World.CameraViewMode.Exterior) {
					if (World.CameraMode != World.CameraViewMode.Interior | !TrainManager.PlayerTrain.Cars[0].Sections[0].Overlay) {
						UpdateCamera(Train);
					}
				}
			}
			// delayed handles
			{ /// power notch
				if (Train.Specs.CurrentPowerNotch.DelayedChanges.Length == 0) {
					if (Train.Specs.CurrentPowerNotch.Security < Train.Specs.CurrentPowerNotch.Actual) {
						if (Train.Specs.PowerNotchReduceSteps <= 1) {
							Train.Specs.CurrentPowerNotch.AddChange(Train, Train.Specs.CurrentPowerNotch.Actual - 1, Train.Specs.DelayPowerDown);
						} else if (Train.Specs.CurrentPowerNotch.Security + Train.Specs.PowerNotchReduceSteps <= Train.Specs.CurrentPowerNotch.Actual | Train.Specs.CurrentPowerNotch.Security == 0) {
							Train.Specs.CurrentPowerNotch.AddChange(Train, Train.Specs.CurrentPowerNotch.Security, Train.Specs.DelayPowerDown);
						}
					} else if (Train.Specs.CurrentPowerNotch.Security > Train.Specs.CurrentPowerNotch.Actual) {
						Train.Specs.CurrentPowerNotch.AddChange(Train, Train.Specs.CurrentPowerNotch.Actual + 1, Train.Specs.DelayPowerUp);
					}
				} else {
					int m = Train.Specs.CurrentPowerNotch.DelayedChanges.Length - 1;
					if (Train.Specs.CurrentPowerNotch.Security < Train.Specs.CurrentPowerNotch.DelayedChanges[m].Value) {
						Train.Specs.CurrentPowerNotch.AddChange(Train, Train.Specs.CurrentPowerNotch.Security, Train.Specs.DelayPowerDown);
					} else if (Train.Specs.CurrentPowerNotch.Security > Train.Specs.CurrentPowerNotch.DelayedChanges[m].Value) {
						Train.Specs.CurrentPowerNotch.AddChange(Train, Train.Specs.CurrentPowerNotch.Security, Train.Specs.DelayPowerUp);
					}
				}
				if (Train.Specs.CurrentPowerNotch.DelayedChanges.Length >= 1) {
					if (Train.Specs.CurrentPowerNotch.DelayedChanges[0].Time <= Game.SecondsSinceMidnight) {
						Train.Specs.CurrentPowerNotch.Actual = Train.Specs.CurrentPowerNotch.DelayedChanges[0].Value;
						Train.Specs.CurrentPowerNotch.RemoveChanges(1);
					}
				}
			}
			{ /// brake notch
				int sec = Train.Specs.CurrentEmergencyBrake.Security ? Train.Specs.MaximumBrakeNotch : Train.Specs.CurrentBrakeNotch.Security;
				if (Train.Specs.CurrentBrakeNotch.DelayedChanges.Length == 0) {
					if (sec < Train.Specs.CurrentBrakeNotch.Actual) {
						Train.Specs.CurrentBrakeNotch.AddChange(Train, Train.Specs.CurrentBrakeNotch.Actual - 1, Train.Specs.DelayBrakeDown);
					} else if (sec > Train.Specs.CurrentBrakeNotch.Actual) {
						Train.Specs.CurrentBrakeNotch.AddChange(Train, Train.Specs.CurrentBrakeNotch.Actual + 1, Train.Specs.DelayBrakeUp);
					}
				} else {
					int m = Train.Specs.CurrentBrakeNotch.DelayedChanges.Length - 1;
					if (sec < Train.Specs.CurrentBrakeNotch.DelayedChanges[m].Value) {
						Train.Specs.CurrentBrakeNotch.AddChange(Train, sec, Train.Specs.DelayBrakeDown);
					} else if (sec > Train.Specs.CurrentBrakeNotch.DelayedChanges[m].Value) {
						Train.Specs.CurrentBrakeNotch.AddChange(Train, sec, Train.Specs.DelayBrakeUp);
					}
				}
				if (Train.Specs.CurrentBrakeNotch.DelayedChanges.Length >= 1) {
					if (Train.Specs.CurrentBrakeNotch.DelayedChanges[0].Time <= Game.SecondsSinceMidnight) {
						Train.Specs.CurrentBrakeNotch.Actual = Train.Specs.CurrentBrakeNotch.DelayedChanges[0].Value;
						Train.Specs.CurrentBrakeNotch.RemoveChanges(1);
					}
				}
			}
			{ /// air brake handle
				if (Train.Specs.AirBrake.Handle.DelayedValue != AirBrakeHandleState.Invalid) {
					if (Train.Specs.AirBrake.Handle.DelayedTime <= Game.SecondsSinceMidnight) {
						Train.Specs.AirBrake.Handle.Actual = Train.Specs.AirBrake.Handle.DelayedValue;
						Train.Specs.AirBrake.Handle.DelayedValue = AirBrakeHandleState.Invalid;
					}
				} else {
					if (Train.Specs.AirBrake.Handle.Security == AirBrakeHandleState.Release & Train.Specs.AirBrake.Handle.Actual != AirBrakeHandleState.Release) {
						Train.Specs.AirBrake.Handle.DelayedValue = AirBrakeHandleState.Release;
						Train.Specs.AirBrake.Handle.DelayedTime = Game.SecondsSinceMidnight;
					} else if (Train.Specs.AirBrake.Handle.Security == AirBrakeHandleState.Service & Train.Specs.AirBrake.Handle.Actual != AirBrakeHandleState.Service) {
						Train.Specs.AirBrake.Handle.DelayedValue = AirBrakeHandleState.Service;
						Train.Specs.AirBrake.Handle.DelayedTime = Game.SecondsSinceMidnight;
					} else if (Train.Specs.AirBrake.Handle.Security == AirBrakeHandleState.Lap) {
						Train.Specs.AirBrake.Handle.Actual = AirBrakeHandleState.Lap;
					}
				}
			}
			{ /// emergency brake
				if (Train.Specs.CurrentEmergencyBrake.Security & !Train.Specs.CurrentEmergencyBrake.Actual) {
					double t = Game.SecondsSinceMidnight;
					if (t < Train.Specs.CurrentEmergencyBrake.ApplicationTime) Train.Specs.CurrentEmergencyBrake.ApplicationTime = t;
					if (Train.Specs.CurrentEmergencyBrake.ApplicationTime <= Game.SecondsSinceMidnight) {
						Train.Specs.CurrentEmergencyBrake.Actual = true;
						Train.Specs.CurrentEmergencyBrake.ApplicationTime = double.MaxValue;
					}
				} else if (!Train.Specs.CurrentEmergencyBrake.Security) {
					Train.Specs.CurrentEmergencyBrake.Actual = false;
				}
			}
			Train.Specs.CurrentHoldBrake.Actual = Train.Specs.CurrentHoldBrake.Driver;
			// update speeds
			UpdateSpeeds(Train, TimeElapsed);
			// run sound
			for (int i = 0; i < Train.Cars.Length; i++) {
				const double invfac = 0.04; /// 90 km/h -> 1/x -> m/s
				double spd = Math.Abs(Train.Cars[i].Specs.CurrentSpeed);
				if (Train.Cars[i].Derailed) spd = 0.0;
				double pitch = spd * invfac;
				double basegain = spd <= 2.77777777777778 ? 0.36 * spd : 1.0;
				for (int j = 0; j < Train.Cars[i].Sounds.Run.Length; j++) {
					if (j == Train.Cars[i].Sounds.FrontAxleRunIndex | j == Train.Cars[i].Sounds.RearAxleRunIndex) {
						Train.Cars[i].Sounds.RunVolume[j] += 3.0 * TimeElapsed;
						if (Train.Cars[i].Sounds.RunVolume[j] > 1.0) Train.Cars[i].Sounds.RunVolume[j] = 1.0;
					} else {
						Train.Cars[i].Sounds.RunVolume[j] -= 3.0 * TimeElapsed;
						if (Train.Cars[i].Sounds.RunVolume[j] < 0.0) Train.Cars[i].Sounds.RunVolume[j] = 0.0;
					}
					double gain = basegain * Train.Cars[i].Sounds.RunVolume[j];
					if (Train.Cars[i].Sounds.Run[j].SoundSourceIndex >= 0) {
						if (pitch > 0.01 & gain > 0.001) {
							SoundManager.ModulateSound(Train.Cars[i].Sounds.Run[j].SoundSourceIndex, pitch, gain);
						} else {
							SoundManager.StopSound(ref Train.Cars[i].Sounds.Run[j].SoundSourceIndex);
						}
					} else if (pitch > 0.02 & gain > 0.01) {
						int snd = Train.Cars[i].Sounds.Run[j].SoundBufferIndex;
						if (snd >= 0) {
							World.Vector3D pos = Train.Cars[i].Sounds.Run[j].Position;
							SoundManager.PlaySound(ref Train.Cars[i].Sounds.Run[j].SoundSourceIndex, snd, Train, i, pos, SoundManager.Importance.DontCare, true, pitch, gain);
						}
					}
				}
			}
			// motor sound
			for (int i = 0; i < Train.Cars.Length; i++) {
				if (Train.Cars[i].Specs.IsMotorCar) {
					World.Vector3D pos = Train.Cars[i].Sounds.Motor.Position;
					double speed = Math.Abs(Train.Cars[i].Specs.CurrentPerceivedSpeed);
					int idx = (int)Math.Round(speed * Train.Cars[i].Sounds.Motor.SpeedConversionFactor);
					int odir = Train.Cars[i].Sounds.Motor.CurrentAccelerationDirection;
					int ndir = Math.Sign(Train.Cars[i].Specs.CurrentAccelerationOutput);
					for (int h = 0; h < 2; h++) {
						int j = h == 0 ? TrainManager.MotorSound.MotorP1 : TrainManager.MotorSound.MotorP2;
						int k = h == 0 ? TrainManager.MotorSound.MotorB1 : TrainManager.MotorSound.MotorB2;
						if (odir > 0 & ndir <= 0) {
							if (j < Train.Cars[i].Sounds.Motor.Tables.Length) {
								SoundManager.StopSound(ref Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex);
								Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex = -1;
							}
						} else if (odir < 0 & ndir >= 0) {
							if (k < Train.Cars[i].Sounds.Motor.Tables.Length) {
								SoundManager.StopSound(ref Train.Cars[i].Sounds.Motor.Tables[k].SoundSourceIndex);
								Train.Cars[i].Sounds.Motor.Tables[k].SoundBufferIndex = -1;
							}
						}
						if (ndir != 0) {
							if (ndir < 0) j = k;
							if (j < Train.Cars[i].Sounds.Motor.Tables.Length) {
								int idx2 = idx;
								if (idx2 >= Train.Cars[i].Sounds.Motor.Tables[j].Entries.Length) {
									idx2 = Train.Cars[i].Sounds.Motor.Tables[j].Entries.Length - 1;
								}
								if (idx2 >= 0) {
									int obuf = Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex;
									int nbuf = Train.Cars[i].Sounds.Motor.Tables[j].Entries[idx2].SoundBufferIndex;
									double pitch = Train.Cars[i].Sounds.Motor.Tables[j].Entries[idx2].Pitch;
									double gain = Train.Cars[i].Sounds.Motor.Tables[j].Entries[idx2].Gain;
									if (ndir == 1) {
										/// power
										double max = Train.Cars[i].Specs.AccelerationCurveMaximum;
										if (max != 0.0) {
											double cur = Train.Cars[i].Specs.CurrentAccelerationOutput;
											if (cur < 0.0) cur = 0.0;
											gain *= Math.Pow(cur / max, 0.25);
										}
									} else if (ndir == -1) {
										/// brake
										double max = Train.Cars[i].Specs.BrakeDecelerationAtServiceMaximumPressure;
										if (max != 0.0) {
											double cur = -Train.Cars[i].Specs.CurrentAccelerationOutput;
											if (cur < 0.0) cur = 0.0;
											gain *= Math.Pow(cur / max, 0.25);
										}
									}
									if (obuf != nbuf) {
										SoundManager.StopSound(ref Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex);
										Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex = -1;
										if (nbuf >= 0) {
											SoundManager.PlaySound(ref Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex, nbuf, Train, i, pos, SoundManager.Importance.DontCare, true, pitch, gain);
											Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex = nbuf;
										}
									} else if (nbuf >= 0) {
										int src = Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex;
										if (src >= 0) {
											SoundManager.ModulateSound(src, pitch, gain);
										}
									} else {
										SoundManager.StopSound(ref Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex);
										Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex = -1;
									}
								} else {
									SoundManager.StopSound(ref Train.Cars[i].Sounds.Motor.Tables[j].SoundSourceIndex);
									Train.Cars[i].Sounds.Motor.Tables[j].SoundBufferIndex = -1;
								}
							}
						}
					}
					Train.Cars[i].Sounds.Motor.CurrentAccelerationDirection = ndir;
				}
			}
			// security system
			if (!Game.MinimalisticSimulation | Train != PlayerTrain) {
				UpdateSecuritySystem(Train, TimeElapsed);
			}
			// passengers
			UpdateTrainPassengers(Train, TimeElapsed);
			// signals
			if (Train.CurrentSectionLimit == 0.0) {
				if (Train.Specs.CurrentEmergencyBrake.Driver & Train.Specs.CurrentAverageSpeed > -0.05 & Train.Specs.CurrentAverageSpeed < 0.05) {
					Train.CurrentSectionLimit = 4.16666666666667;
					if (Train == PlayerTrain) {
						string s = Interface.GetInterfaceString("message_signal_proceed");
						double a = 3.6 * Train.CurrentSectionLimit;
						s = s.Replace("[speed]", a.ToString("0", System.Globalization.CultureInfo.InvariantCulture));
						Game.AddMessage(s, Game.MessageDependency.None, Interface.GameMode.Normal, Game.MessageColor.Red, Game.SecondsSinceMidnight + 5.0);
					}
				}
			}
			// infrequent updates
			Train.InternalTimerTimeElapsed += TimeElapsed;
			if (Train.InternalTimerTimeElapsed > 10.0) {
				Train.InternalTimerTimeElapsed -= 10.0;
				SynchronizeTrain(Train);
				UpdateAtmosphericConstants(Train);
			}
		}

	}
}
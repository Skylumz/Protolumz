using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public enum MetaType : uint
    {
        PropRestoreDataArray = 2173087383,

        AchievementsManager = 3352760320,
        StatsManager = 1704301288,
        PersonalBestThreshold = 4086179281,

        NPCInstancePool = 3529804714,
        NPCDrawable = 1471376677,
        NPCType = 1987898676,
        NPCRender = 1025374863,
        PedestrianSpawner = 1174351712,

        ShaderPalette = 1359486408,

        LODAnimationInfoListTemplate = 3309078827,
        AmbientExclusionVolume = 466667055,
        SimplePhysicsObjectFactory = 3711084174,
        WhipFistPower = 10511182,
        TendrilPower = 3907123361,
        TokenWeights = 477332489,
        DisguiseIncidentConfig = 1939985585,

        SupportingLimbDefinitionList = 2879966630,
        SupportingLimbDefinition = 508261517,

        DamageScale = 104023774,
        CharacterZoneDamageProperties = 3727486622,
        AtlasInfo = 4085786704,
        AirCameraTunables = 483273957,
        ChaseCameraTunables = 2936952957,
        SmartTargetCamera = 1624457702,
        ChaseCameraSettings = 901321416,
        oseMirrorPartitionLoadObject = 3408415242,
        DismembermentCutList = 1830363640,
        AnalyseCollisionParams = 3494946021,
        MomentumDamageParams = 2956375238,
        CharacterSolverProperties = 1784948523,
        AttachmentPhysicsProperties = 1513115060,
        ConstraintAngularVelocitySharedProperties = 1801857568,
        ConstraintAngularSpringSharedProperties = 122490656,
        ConstraintSpringAlongAxisSharedProperties = 2116810755,
        DeformableOrientationConstraintSharedProperties = 244410052,
        DeformableSliderConstraintSharedProperties = 1599977220,
        PoweredConstraintSharedProperties = 684669764,
        PoweredRagdollProperties = 403898115,
        MaterialLoader = 1808933341,
        ColliderTypeNames = 2016464643,
        IntersectionPropertiesLoader = 2366705205,
        PoseFixupProperties = 1106286942,
        MassProperties = 4115583528,
        PhysicsObjectFactory = 1472880679,
        SmartNodeArray = 2450159653,

        WebDrawablePoolLoader = 3363017779,
        WebSegmentDataLoader = 382870263,
        WebAnchorConeConfig = 1821657391,
        WebConnectionConfigParams = 942661499,
        WebReceiverBundleKnotProperties = 996172244,
        WebReceiverConnectionProperties = 802529523,
        WebReceiverProperties = 3804428962,

        ArtilleryStrikeSpawnProfile = 2568114286,
        BulletTracerProfile = 698765973,
        GunAmmoProfile = 3214763909,
        MissileSpawnProfile = 335637534,
        MissileProfile = 1795643182,
        WeaponUserProfile = 3767204762,

        TransformationDescription = 1705969966,
        ActionPromptConfig = 3547757846,
        AIGroupCreationTemplate = 2785623559,
        CharacterBudgetPolicyList = 2439320315,
        TargetSelectionWeights = 760925779,
        AutoTargetPriorityList = 1165531545,
        AlertManagerProperties = 1552722049,
        UnlockablesList = 1794577786,
        DifficultySettings = 3851094813,
        PlacementAssetCategory = 2082739923,
        PlacementPackage = 2980034307,
        StreamPackage = 804020905,
        SubtitleManager = 1158764426,
        GameObject = 3240679725,
        GameObjectTemplateBuilder = 3246008931,
        PropTemplate = 3387795030,

        Address = 3841554896,
        AddressPrefabRoot = 1691364145,
        AddressTypes = 3487076079,

        HitTypeDescription = 4058898212,

        LightTextureSet = 935940809,
        GlobalTextureSet = 389237785,
        ConsumeTextureSet = 50933654,

        AmbientFormationTemplate = 386822268,
        DeformShaderProperties = 1504797505,
        EffectPropParamsList = 1090289653,
        DeformAudioProperties = 1410266080,
        CharacterIntentionInputMap = 2003674137,
        ConsumeUniquePrimitiveSet = 1749753374,
        ConsumableProperties = 192926066,
        DLCPackageInfoList = 2944030467,
    }

    public class MetaObjectDefinitionNode : P3DNode
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string TypeName { get; set; }
        public ushort Unknown4 { get; set; }
        public ushort Unknown5 { get; set; }
        public MetaType MetaType { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            LongName = dr.ReadByteSizedString();
            ShortName = dr.ReadByteSizedString();
            TypeName = dr.ReadByteSizedString();
            Unknown4 = dr.ReadUInt16();
            Unknown5 = dr.ReadUInt16();
            MetaType = (MetaType)dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", Type, MetaType, ShortName);
        }
    }

    public class MetaObjectDataNode : P3DNode
    {
        public uint NodeDataLength { get; set; }
        public byte[] NodeData { get; set; }


        public override void Read(DataReader dr)
        {
            base.Read(dr);

            NodeDataLength = dr.ReadUInt32();
            NodeData = dr.ReadBytes((int)NodeDataLength);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} bytes", Type, NodeDataLength);
        }
    }
}

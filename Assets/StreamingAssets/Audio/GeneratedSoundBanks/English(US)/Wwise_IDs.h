/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BELL_TONE = 229829620U;
        static const AkUniqueID PLAY_COLLECT_FRUIT = 726221595U;
        static const AkUniqueID PLAY_DIGGING = 813141615U;
        static const AkUniqueID PLAY_EAT_FRUIT = 898820479U;
        static const AkUniqueID PLAY_FALLING_FRUIT = 3771967532U;
        static const AkUniqueID PLAY_FISH_ESCAPING = 2110151795U;
        static const AkUniqueID PLAY_FISHING_REEL = 4160459651U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_HEALTH_SFX = 503952552U;
        static const AkUniqueID PLAY_LAKE_WAVES_LAPPING = 4112892722U;
        static const AkUniqueID PLAY_MONOLITH = 2134478874U;
        static const AkUniqueID PLAY_PLANT_TREE = 2709727076U;
        static const AkUniqueID PLAY_PLAYER_EVENT_MANAGER = 3690526740U;
        static const AkUniqueID PLAY_TESTBEEP = 1955951874U;
        static const AkUniqueID PLAY_TESTBEEP2 = 2303144468U;
        static const AkUniqueID PLAY_TREE_EMITTER = 3564794469U;
        static const AkUniqueID PLAY_ZONES = 3780807851U;
        static const AkUniqueID STOP_ALL = 452547817U;
        static const AkUniqueID STOP_HEALTH_SFX = 2472861354U;
        static const AkUniqueID STOP_LAKE_WAVES_LAPPING = 1724707056U;
        static const AkUniqueID STOP_PLAYER_EVENT_MANAGER = 1721880682U;
        static const AkUniqueID STOP_TREE_EMITTER = 1538482647U;
        static const AkUniqueID STOP_ZONES = 914123949U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYER_EVENTS
        {
            static const AkUniqueID GROUP = 2993354578U;

            namespace STATE
            {
                static const AkUniqueID EMPTY = 3354297748U;
                static const AkUniqueID IN_WORLD = 2273743309U;
            } // namespace STATE
        } // namespace PLAYER_EVENTS

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEP_SURFACE
        {
            static const AkUniqueID GROUP = 1833605183U;

            namespace SWITCH
            {
                static const AkUniqueID FOREST_FLOOR = 2592332705U;
            } // namespace SWITCH
        } // namespace FOOTSTEP_SURFACE

        namespace PLAYER_FOREST_ZONE
        {
            static const AkUniqueID GROUP = 2958763795U;

            namespace SWITCH
            {
                static const AkUniqueID CAVE = 4122393694U;
                static const AkUniqueID FOREST_FLOOR = 2592332705U;
                static const AkUniqueID LAKESIDE = 2190861365U;
            } // namespace SWITCH
        } // namespace PLAYER_FOREST_ZONE

        namespace WORLD_ZONE
        {
            static const AkUniqueID GROUP = 2657943960U;

            namespace SWITCH
            {
                static const AkUniqueID DESERT = 1850388778U;
                static const AkUniqueID FOREST = 491961918U;
                static const AkUniqueID MOUNTAIN = 513139656U;
            } // namespace SWITCH
        } // namespace WORLD_ZONE

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID BIRD_POPULATION = 2770716474U;
        static const AkUniqueID COMBO_STRENGTH = 2556877779U;
        static const AkUniqueID DEPTH_DUG = 1139232757U;
        static const AkUniqueID FISH_DISTANCE = 1567132679U;
        static const AkUniqueID FISH_POPULATION = 705187635U;
        static const AkUniqueID INTERACTION_PERCUSSION = 1898339869U;
        static const AkUniqueID INTERACTION_SUCCESS_RHYTHM = 2807882626U;
        static const AkUniqueID PLAYER_HEALTH = 215992295U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID DISCOVERED_TREE = 1946655246U;
        static const AkUniqueID ENTERED_WORLD = 4134113183U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID NARRATIVE_SCORE = 1554040882U;
        static const AkUniqueID PLAYER_SFX = 817096458U;
        static const AkUniqueID TREE_AMBIENT = 3749599892U;
        static const AkUniqueID ZONE_AMBIENCE = 4262403134U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__

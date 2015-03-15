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
        static const AkUniqueID PLAY_EAT_FRUIT = 898820479U;
        static const AkUniqueID PLAY_FALLING_FRUIT = 3771967532U;
        static const AkUniqueID PLAY_HEALTH_SFX = 503952552U;
        static const AkUniqueID PLAY_LAKE_WAVES_LAPPING = 4112892722U;
        static const AkUniqueID PLAY_PLANT_TREE = 2709727076U;
        static const AkUniqueID PLAY_PLAYER_EVENT_MANAGER = 3690526740U;
        static const AkUniqueID PLAY_TREE_EMITTER = 3564794469U;
        static const AkUniqueID PLAY_TREE_STATE = 4258997712U;
        static const AkUniqueID PLAY_ZONES = 3780807851U;
        static const AkUniqueID STOP_PLAYER_EVENT_MANAGER = 1721880682U;
        static const AkUniqueID STOP_TREE_STATE = 116774218U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYER_EVENTS
        {
            static const AkUniqueID GROUP = 2993354578U;

            namespace STATE
            {
                static const AkUniqueID COLLECTING = 2908999423U;
                static const AkUniqueID ENTERED_WORLD = 4134113183U;
                static const AkUniqueID WANDERING = 342806866U;
            } // namespace STATE
        } // namespace PLAYER_EVENTS

    } // namespace STATES

    namespace SWITCHES
    {
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

        namespace TREE_STATES
        {
            static const AkUniqueID GROUP = 4072258362U;

            namespace SWITCH
            {
                static const AkUniqueID BTREE = 656847401U;
                static const AkUniqueID BUSH = 1427625975U;
                static const AkUniqueID MTREE = 2169647486U;
                static const AkUniqueID SAPLING = 1558384023U;
                static const AkUniqueID STREE = 1094844220U;
            } // namespace SWITCH
        } // namespace TREE_STATES

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
        static const AkUniqueID EATING_FRUIT = 3386581620U;
        static const AkUniqueID PLANTING_TREES = 164040730U;
        static const AkUniqueID PLAYER_HEALTH = 215992295U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID DISCOVERED_TREE = 1946655246U;
        static const AkUniqueID ENTERED_WORLD = 4134113183U;
        static const AkUniqueID PICKED_UP_SEED = 1600046017U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID NARRATIVE_SCORE = 1554040882U;
        static const AkUniqueID PLAYER_SFX = 817096458U;
        static const AkUniqueID TREE_AMBIENT = 3749599892U;
        static const AkUniqueID TREE_MUSIC = 2261192469U;
        static const AkUniqueID ZONE_AMBIENCE = 4262403134U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__

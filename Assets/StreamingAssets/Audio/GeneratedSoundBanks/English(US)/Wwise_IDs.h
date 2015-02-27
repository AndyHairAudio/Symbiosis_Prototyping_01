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
        static const AkUniqueID PLAY_ENTRANCE_MUSIC = 4075369248U;
        static const AkUniqueID PLAY_FALLING_FRUIT = 3771967532U;
        static const AkUniqueID PLAY_TREE_EMITTER = 3564794469U;
        static const AkUniqueID PLAY_TREE_STATE = 4258997712U;
        static const AkUniqueID PLAY_ZONES = 3780807851U;
        static const AkUniqueID STOP_FALLING_FRUIT = 2900363446U;
        static const AkUniqueID STOP_TREE_EMITTER = 1538482647U;
        static const AkUniqueID STOP_TREE_STATE = 116774218U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace TEMPO_GLOBAL
        {
            static const AkUniqueID GROUP = 2868541796U;

            namespace STATE
            {
                static const AkUniqueID ACTIVE = 58138747U;
                static const AkUniqueID INACTIVE = 3163453698U;
            } // namespace STATE
        } // namespace TEMPO_GLOBAL

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

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID NARRATIVE_SCORE = 1554040882U;
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

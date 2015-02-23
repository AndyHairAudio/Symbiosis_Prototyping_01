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
        static const AkUniqueID PLAY_CHIRP = 3187155090U;
        static const AkUniqueID PLAY_TREE_MUSIC = 2107565590U;
        static const AkUniqueID STOP_TREE_MUSIC = 230488276U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYER_HEALTH
        {
            static const AkUniqueID GROUP = 215992295U;

            namespace STATE
            {
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID DYING = 3328495488U;
                static const AkUniqueID HEALTHY = 2874639328U;
                static const AkUniqueID LIVELY = 321744434U;
                static const AkUniqueID WEAK = 1488596377U;
                static const AkUniqueID WOUNDED = 1764828697U;
            } // namespace STATE
        } // namespace PLAYER_HEALTH

        namespace TREE_STATES
        {
            static const AkUniqueID GROUP = 4072258362U;

            namespace STATE
            {
                static const AkUniqueID BTREE = 656847401U;
                static const AkUniqueID BUSH = 1427625975U;
                static const AkUniqueID MTREE = 2169647486U;
                static const AkUniqueID SAPLING = 1558384023U;
                static const AkUniqueID STREE = 1094844220U;
            } // namespace STATE
        } // namespace TREE_STATES

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID FOREST_FLOOR_AMBIENCE = 3578186316U;
        static const AkUniqueID TREE_MUSIC = 2261192469U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__

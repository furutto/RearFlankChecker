using System;
using Advanced_Combat_Tracker;

namespace RearFlankChecker.Util
{
    class CombatActionChecker
    {

        public static bool IsMySkill(CombatActionEventArgs actionInfo)
        {
            // 自分のスキルかどうか（名前のバッティングは？）
            if (!actionInfo.combatAction.Attacker.Equals(ActGlobals.charName))
            {
                return false;
            }
            // 2がスキルっぽい（1がオートアタック、Dotも2以外）
            if (actionInfo.swingType != 2)
            {
                return false;
            }

            return true;
        }

        public static bool JudgeFlankOrRearSkill(CombatActionEventArgs actionInfo)
        {
            Boolean isJudge = true;

            // スキルID取得
            Object oSkillId = null;
            actionInfo.tags.TryGetValue("SkillID", out oSkillId);
            int numId = Convert.ToInt32(oSkillId);

            // ダメージ補正（コンボや方向指定の成功により加算されているようである）
            Object oDmgAdjust = null;
            actionInfo.tags.TryGetValue("DmgAdjust", out oDmgAdjust);
            String sDmgAdjust = oDmgAdjust == null ? "" : oDmgAdjust.ToString();

            switch (numId)
            {
                // 忍者
                case 2255:  // 旋風刃
                    isJudge = sDmgAdjust.Equals("0.7");
                    break;
                case 3563:  // 強甲破点突
                    isJudge = sDmgAdjust.Equals("0.66");
                    break;
                case 2258:  // だまし
                    isJudge = !sDmgAdjust.Equals("");
                    break;
                //  竜騎士
                case 88:  // 桜華
                    //isJudge = sDmgAdjust.Equals("0.64");
                    // コンボ失敗して背面攻撃したら 0.28（コンボ成功時のみ考慮で良いとは思うが一応追加した）
                    isJudge = sDmgAdjust.Equals("0.64") || sDmgAdjust.Equals("0.28");
                    break;
                case 79:  // ヘヴィスラスト
                case 3554:  // 竜牙竜爪（側面）
                case 3556:  // 竜尾大車輪（背面）
                    isJudge = !sDmgAdjust.Equals("");
                    break;
                // モンク
                case 53:  // 連撃
                    // 連撃ならクリティカルかどうかだけで判定（背面じゃなくても、壱の型でなくてもクリティカルならヒットしてしまう）
                    isJudge = actionInfo.critical;
                    break;
                case 74:  // 双竜脚
                case 61:  // 双掌打
                case 56:  // 崩拳
                case 54:  // 正拳突き
                case 66:  // 破砕拳
                    isJudge = !sDmgAdjust.Equals("");
                    break;
                default:
                    isJudge = true;
                    break;
            }

            return isJudge;
        }
    }
}

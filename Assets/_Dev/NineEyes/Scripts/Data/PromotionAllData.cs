using Grandora.Heimdall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotionAllData : NetworkData
{
    public override string UserId => "";
    public List<PromotionPage> PromotionPages;
}
public struct PromotionPage
{
    public string id;
    public int priority;
    public int layout;
    public string mSPromo1_Id;
    public string mSPromo2_Id;
    public string mSPromo3_Id;
    public string mSPromo4_Id;
    public string mSPromo5_Id;
    public string mSPromo6_Id;
    public string mSPromo7_Id;
    public string mSPromo8_Id;
    public string mSPromo9_Id;
    public string EffectiveAt;
    public string EffectiveUntil;
    public string createdAt;
    public string updatedAt;
    public PromotionData promo1;
    public PromotionData promo2;
    public PromotionData promo3;
    public PromotionData promo4;
    public PromotionData promo5;
    public PromotionData promo6;
    public PromotionData promo7;
    public PromotionData promo8;
    public PromotionData promo9;
}
public class PromotionData
{
    public string id;
    public string msPromotionCode;
    public string model;
    public string title_en;
    public string title_th;
    public string title_zh_hant;
    public string title_zh_hans;
    public string title_de;
    public string title_fr;
    public string title_ko;
    public string title_jp;
    public string title_es;
    public string title_ru;
    public string description_en;
    public string description_th;
    public string description_zh_hant;
    public string description_zh_hans;
    public string description_de;
    public string description_fr;
    public string description_ko;
    public string description_jp;
    public string description_es;
    public string description_ru;
    public string image_1_1_Url_en;
    public string image_1_1_Url_th;
    public string image_1_1_Url_zh_hant;
    public string image_1_1_Url_zh_hans;
    public string image_1_1_Url_de;
    public string image_1_1_Url_fr;
    public string image_1_1_Url_ko;
    public string image_1_1_Url_jp;
    public string image_1_1_Url_es;
    public string image_1_1_Url_ru;
    public string image_2_1_Url_en;
    public string image_2_1_Url_th;
    public string image_2_1_zh_hant;
    public string image_2_1_zh_hans;
    public string image_2_1_de;
    public string image_2_1_fr;
    public string image_2_1_ko;
    public string image_2_1_jp;
    public string image_2_1_es;
    public string image_2_1_ru;
    public string image_1_2_Url_en;
    public string image_1_2_Url_th;
    public string image_1_2_Url_zh_hant;
    public string image_1_2_Url_zh_hans;
    public string image_1_2_Url_de;
    public string image_1_2_Url_fr;
    public string image_1_2_Url_ko;
    public string image_1_2_Url_jp;
    public string image_1_2_Url_es;
    public string image_1_2_Url_ru;
    public string image_3_1_Url_en;
    public string image_3_1_Url_th;
    public string image_3_1_Url_zh_hant;
    public string image_3_1_Url_zh_hans;
    public string image_3_1_Url_de;
    public string image_3_1_Url_fr;
    public string image_3_1_Url_ko;
    public string image_3_1_Url_jp;
    public string image_3_1_Url_es;
    public string image_3_1_Url_ru;
    public string image_3_2_Url_en;
    public string image_3_2_Url_th;
    public string image_3_2_zh_hant;
    public string image_3_2_zh_hans;
    public string image_3_2_de;
    public string image_3_2_fr;
    public string image_3_2_ko;
    public string image_3_2_jp;
    public string image_3_2_es;
    public string image_3_2_ru;
    public List<string> msPrivilegeIDs;
    public string priceMode;
    public string promotionRewardId;
    public int priceInDiamond;
    public float priceInDollar;
    public string priceAppleID;
    public string priceAndroidID;
    public string createdAt;
    public string updatedAt;
    public List<PrivilegesCodeData> msPrivileges;

}
public struct PrivilegesCodeData
{
    public string id;
    public string msPrivilegeCode;
}

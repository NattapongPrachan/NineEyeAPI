using Grandora.Heimdall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivilegeAllData : NetworkData
{
    public override string UserId => "";
    public List<PrivilegeData> PrivilegeList;
}
public class PrivilegeData : NetworkData
{
    public override string UserId => "";
    public bool enable;
    public string msPrivilegeCode;
    public string msParentPrivilegeCode;
    public string imageUrl_en;
    public string imageUrl_th;
    public string imageUrl_zh_hant;
    public string imageUrl_zh_hans;
    public string imageUrl_de;
    public string imageUrl_fr;
    public string imageUrl_ko;
    public string imageUrl_jp;
    public string imageUrl_es;
    public string imageUrl_ru;
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
    public string mapStatCode;
    public int dayCount;
    public string priceMode;
    public int priceInDiamond;
    public int priceInDollar;
    public string priceAppleID;
    public string priceAndroidID;
    public string createdAt;
    public string updatedAt;
    public List<string> msPromotionIDs;
    public string msParentPrivilege;
}

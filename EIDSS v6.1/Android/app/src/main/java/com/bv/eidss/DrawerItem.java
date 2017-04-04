package com.bv.eidss;

public class DrawerItem {

	long ItemID;
	int imgResID;
    String title;
    int type;

    public static DrawerItem newInstance(String title, int imgResID) {
        return new DrawerItem(0, title, imgResID, CustomDrawerAdapter.TYPE_TITLE);
    }

    public static DrawerItem newInstance(String title) {
        return new DrawerItem(0, title, 0, CustomDrawerAdapter.TYPE_HEADER);
    }

    public static DrawerItem newInstance(long id, String title, int imgResID, boolean isFirst) {
        if(isFirst)
            return new DrawerItem(id, title, imgResID, CustomDrawerAdapter.TYPE_ITEM_FIRST);
        else
            return new DrawerItem(id, title, imgResID, CustomDrawerAdapter.TYPE_ITEM);
    }

    private DrawerItem(long id, String title, int imgResID, int type) {
        ItemID = id;
        this.title = title;
        this.imgResID = imgResID;
        this.type = type;
    }

    public final int getItemType() {
        return type;
    }

    public final long getItemID() {
        return ItemID;
    }

    public final int getImgResID() {
        return imgResID;
    }

	public final String getTitle() {
		return title;
	}

}

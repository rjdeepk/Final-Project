package md5323a864b2da0996f18439102502a2004;


public class RestaurantPage2
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RestaurantApp.RestaurantPage2, RestaurantApp", RestaurantPage2.class, __md_methods);
	}


	public RestaurantPage2 ()
	{
		super ();
		if (getClass () == RestaurantPage2.class)
			mono.android.TypeManager.Activate ("RestaurantApp.RestaurantPage2, RestaurantApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
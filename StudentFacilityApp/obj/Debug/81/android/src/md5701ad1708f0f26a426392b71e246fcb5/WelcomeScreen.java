package md5701ad1708f0f26a426392b71e246fcb5;


public class WelcomeScreen
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
		mono.android.Runtime.register ("StudentFacilityApp.WelcomeScreen, StudentFacilityApp", WelcomeScreen.class, __md_methods);
	}


	public WelcomeScreen ()
	{
		super ();
		if (getClass () == WelcomeScreen.class)
			mono.android.TypeManager.Activate ("StudentFacilityApp.WelcomeScreen, StudentFacilityApp", "", this, new java.lang.Object[] {  });
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

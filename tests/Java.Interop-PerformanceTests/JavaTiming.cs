using System;

using Java.Interop;

namespace Java.Interop.PerformanceTests
{
	public class JavaTiming : JavaObject
	{
		static JniType _TypeRef;
		internal static JniType TypeRef {
			get {return JniType.GetCachedJniType (ref _TypeRef, "com/xamarin/interop/performance/JavaTiming");}
		}

		static JniInstanceMethodID Object_ctor;
		static JniLocalReference _NewObject ()
		{
			TypeRef.GetCachedConstructor (ref Object_ctor, "()V");
			return TypeRef.NewObject (Object_ctor);
		}

		public JavaTiming ()
			: base (_NewObject (), JniHandleOwnership.Transfer)
		{
		}

		static JniStaticMethodID svm;
		public static void StaticVoidMethod ()
		{
			TypeRef.GetCachedStaticMethod (ref svm, "StaticVoidMethod", "()V");
			svm.CallVoidMethod (TypeRef.SafeHandle);
		}

		static JniStaticMethodID sim;
		public static int StaticIntMethod ()
		{
			TypeRef.GetCachedStaticMethod (ref sim, "StaticIntMethod", "()I");
			return sim.CallInt32Method (TypeRef.SafeHandle);
		}

		static JniStaticMethodID som;
		public static IJavaObject StaticObjectMethod ()
		{
			TypeRef.GetCachedStaticMethod (ref som, "StaticObjectMethod", "()Ljava/lang/Object;");
			var lref = som.CallObjectMethod (TypeRef.SafeHandle);
			return JniEnvironment.Current.JavaVM.GetObject (lref, JniHandleOwnership.Transfer);
		}

		static JniInstanceMethodID vvm;
		public virtual void VirtualVoidMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref vvm, "VirtualVoidMethod", "()V");
			vvm.CallVirtualVoidMethod (SafeHandle);
		}

		static JniInstanceMethodID vim;
		public virtual int VirtualIntMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref vim, "VirtualIntMethod", "()I");
			return vim.CallVirtualInt32Method (SafeHandle);
		}

		static JniInstanceMethodID vom;
		public virtual IJavaObject VirtualObjectMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref vom, "VirtualObjectMethod", "()Ljava/lang/Object;");
			var lref = vom.CallVirtualObjectMethod (SafeHandle);
			return JniEnvironment.Current.JavaVM.GetObject (lref, JniHandleOwnership.Transfer);
		}

		static JniInstanceMethodID fvm;
		public void FinalVoidMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref fvm, "FinalVoidMethod", "()V");
			fvm.CallNonvirtualVoidMethod (SafeHandle, TypeRef.SafeHandle);
		}

		static JniInstanceMethodID fim;
		public int FinalIntMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref fim, "FinalIntMethod", "()I");
			return fim.CallNonvirtualInt32Method (SafeHandle, TypeRef.SafeHandle);
		}

		static JniInstanceMethodID fom;
		public IJavaObject FinalObjectMethod ()
		{
			TypeRef.GetCachedInstanceMethod (ref fom, "FinalObjectMethod", "()Ljava/lang/Object;");
			var lref = vom.CallNonvirtualObjectMethod (SafeHandle, TypeRef.SafeHandle);
			return JniEnvironment.Current.JavaVM.GetObject (lref, JniHandleOwnership.Transfer);
		}

		static JniStaticMethodID svm1;
		public static void StaticVoidMethod1Args (IJavaObject obj1)
		{
			TypeRef.GetCachedStaticMethod (ref svm1, "StaticVoidMethod1Args",
					"(Ljava/lang/Object;)V");
			svm1.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1));
		}

		static JniStaticMethodID svm2;
		public static void StaticVoidMethod2Args (IJavaObject obj1, IJavaObject obj2)
		{
			TypeRef.GetCachedStaticMethod (ref svm2, "StaticVoidMethod2Args",
					"(Ljava/lang/Object;Ljava/lang/Object;)V");
			svm2.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1), new JValue (obj2));
		}

		static JniStaticMethodID svm3;
		public static void StaticVoidMethod3Args (IJavaObject obj1, IJavaObject obj2, IJavaObject obj3)
		{
			TypeRef.GetCachedStaticMethod (ref svm3, "StaticVoidMethod3Args",
				"(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)V");
			svm2.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1), new JValue (obj2), new JValue (obj3));
		}

		static JniStaticMethodID svmi1;
		public static void StaticVoidMethod1IArgs (int obj1)
		{
			TypeRef.GetCachedStaticMethod (ref svmi1, "StaticVoidMethod1IArgs", "(I)V");
			svmi1.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1));
		}

		static JniStaticMethodID svmi2;
		public static void StaticVoidMethod2IArgs (int obj1, int obj2)
		{
			TypeRef.GetCachedStaticMethod (ref svmi2, "StaticVoidMethod2IArgs", "(II)V");
			svmi1.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1), new JValue (obj2));
		}

		static JniStaticMethodID svmi3;
		public static void StaticVoidMethod3IArgs (int obj1, int obj2, int obj3)
		{
			TypeRef.GetCachedStaticMethod (ref svmi3, "StaticVoidMethod3IArgs", "(III)V");
			svmi1.CallVoidMethod (TypeRef.SafeHandle, new JValue (obj1), new JValue (obj2), new JValue (obj3));
		}
	}
}


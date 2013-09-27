using System;
using MonoTouch.CoreImage;
using MonoTouch.ObjCRuntime;
using System.Reflection;

namespace coreimage
{
	class FilterHolder
	{
		public string Name { get; private set;}
		public string SectionName { get; private set;}
		public byte MajorVersion { get; private set;}
		public  Func<CIImage> Callback { get; private set;}

		public FilterHolder (string name, string sectionName, byte version, Type filterType, Func<CIImage> callback)
		{
			Name = name;
			SectionName = sectionName;
			Callback = callback;
			MajorVersion = version;
			var attrNum = filterType.GetCustomAttribute <SinceAttribute> ();
			if (attrNum != null && attrNum.Major != version)
				Console.WriteLine ("WANRING!  {0} has not provided the correct version number according to the since attribute.", name);
		}
	}
}


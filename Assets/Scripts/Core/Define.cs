using UnityEngine;

namespace Model
{
	public static class Define
	{
#if UNITY_EDITOR && !ASYNC
		public static bool IsAsync = false;
#else
        public static bool IsAsync = true;
#endif

#if UNITY_EDITOR
		public static bool IsEditorMode = true;
#else
		public static bool IsEditorMode = false;
#endif

#if DEVELOPMENT_BUILD
		public static bool IsDevelopmentBuild = true;
#else
		public static bool IsDevelopmentBuild = false;
#endif

#if ILRuntime
		public static bool IsILRuntime = true;
#else
		public static bool IsILRuntime = false;
#endif
		
		/// <summary>
		///应用程序外部资源路径存放路径(热更新资源路径)
		/// </summary>
		public static string AppHotfixResPath
		{
			get
			{
				string game = Application.productName;
				string path = AppResPath;
				if (Application.isMobilePlatform)
				{
					path = $"{Application.persistentDataPath}/{game}/";
				}
				return path;
			}

		}

		/// <summary>
		/// 应用程序内部资源路径存放路径
		/// </summary>
		public static string AppResPath
		{
			get
			{
				return Application.streamingAssetsPath;
			}
		}

		/// <summary>
		/// 应用程序内部资源路径存放路径(www/webrequest专用)
		/// </summary>
		public static string AppResPath4Web
		{
			get
			{
#if UNITY_IOS || UNITY_STANDALONE_OSX
				return $"file://{Application.streamingAssetsPath}";
#else
                return Application.streamingAssetsPath;
#endif

			}
		}

		public static string GetUrl()
		{
			//web 资源服务器路径
			string url = "";
#if UNITY_ANDROID
			url += "Android/";
#elif UNITY_IOS
			url += "IOS/";
#elif UNITY_WEBGL
			url += "WebGL/";
#elif UNITY_STANDALONE_OSX
			url += "MacOS/";
#else
			url += "PC/";
#endif
			Debug.Log(url);
			return url;
		}
	}
}
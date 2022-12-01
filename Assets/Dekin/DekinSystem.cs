
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonLab
{
	public class DekinSystem : UdonSharpBehaviour
	{
		[Header("出禁にしたいユーザーの名前")]
		[SerializeField]
		private string[] namelist;

		[Header("Steamアカウントの場合")]
		[SerializeField]
		private string[] steamid;
		[Header("ポータル")]
		public GameObject portal;
		private bool black = false;

		void Start()
		{
			var plname = Networking.LocalPlayer.displayName;
			for (int i = 0; i < namelist.Length; i++)
			{
				if (namelist.Length < 1)
					break;
				if (plname == namelist[i])
				{
					black = true;
				}
			}
			for (int i = 0; i < steamid.Length; i++)
			{
				if (steamid.Length < 1)
					break;
				if (plname.Contains(steamid[i]))
				{
					black = true;
				}
			}
			if (!black)
				Destroy(this.gameObject);
		}
		private void Update()
		{
			if (black)
			{
				portal.transform.position = Networking.LocalPlayer.GetPosition();
				portal.SetActive(!portal.activeSelf);
			}
		}
		private void OnDisable()
		{
			this.gameObject.SetActive(true);
		}
	}
}
using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class VCamChanger : MonoBehaviour {
	[SerializeField] private CinemachineVirtualCamera _startVCam;
	[SerializeField] private CinemachineVirtualCamera _bedVCam;
	[SerializeField] private CinemachineVirtualCamera _bedAndWindowVCam;
	[SerializeField] private CinemachineVirtualCamera _characterVCam;
	[SerializeField] private CinemachineVirtualCamera _mGSandwichVCam;

	private const string _startVCamName = "Start";
	private const string _bedVCamName = "Bed";
	private const string _bedAndWindowVCamName = "BedAndWindow";
	private const string _characterVCamName = "Character";
	private const string _mGSandwichVCamName = "MGSandwich";

	private List<CinemachineVirtualCamera> _vCams = new List<CinemachineVirtualCamera>();

	private void Start() {
		_vCams.Add(_startVCam);
		_vCams.Add(_bedVCam);
		_vCams.Add(_bedAndWindowVCam);
		_vCams.Add(_characterVCam);
		_vCams.Add(_mGSandwichVCam);
	}

	public void ChangeVCam(string name) {
		SetVCamPriority(name, 2);
		foreach (var vcam in _vCams) {
			if (vcam.Priority == 1) vcam.Priority = 0;
		}
		SetVCamPriority(name, 1);
	}

	private void SetVCamPriority(string name, int priority) {
		switch (name) {
			case _startVCamName: _startVCam.Priority = priority; break;
			case _bedVCamName: _bedVCam.Priority = priority; break;
			case _bedAndWindowVCamName: _bedAndWindowVCam.Priority = priority; break;
			case _characterVCamName: _characterVCam.Priority = priority; break;
			case _mGSandwichVCamName: _mGSandwichVCam.Priority = priority; break;
		}
	}
}

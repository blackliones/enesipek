
var Radion = 1;
var RadioName : String;

var _SpecialFM : AudioClip[];
var _TrapFM : AudioClip[];
var _TechnoFM : AudioClip[];
var _StreetRaceFM : AudioClip[];
var _RadioPop : AudioClip[];
var _SlowFM : AudioClip[];

private var CurrMusic : AudioClip;

private var R1CM : AudioClip;
private var R2CM : AudioClip;
private var R3CM : AudioClip;
private var R4CM : AudioClip;
private var R5CM : AudioClip;
private var R6CM : AudioClip;

private var R1 : AudioSource;
private var R2 : AudioSource;
private var R3 : AudioSource;
private var R4 : AudioSource;
private var R5 : AudioSource;
private var R6 : AudioSource;

private var R1N = "SpecialFM";
private var R2N = "TrapFM";
private var R3N = "TechnoFM";
private var R4N = "StreetRaceFM";
private var R5N = "RadioPop";
private var R6N = "SlowFM";

var txtRadio : GUIText;

function Start()
{
R1 = gameObject.AddComponent(AudioSource);
R2 = gameObject.AddComponent(AudioSource);
R3 = gameObject.AddComponent(AudioSource);
R4 = gameObject.AddComponent(AudioSource);
R5 = gameObject.AddComponent(AudioSource);
R6 = gameObject.AddComponent(AudioSource);

R1.loop = false;
R2.loop = false;
R3.loop = false;
R4.loop = false;
R5.loop = false;
R6.loop = false;

R1.dopplerLevel = 0;
R1.minDistance = 1;
R1.maxDistance = 3;

R2.dopplerLevel = 0;
R2.minDistance = 1;
R2.maxDistance = 3;

R3.dopplerLevel = 0;
R3.minDistance = 1;
R3.maxDistance = 3;

R4.dopplerLevel = 0;
R4.minDistance = 1;
R4.maxDistance = 3;

R5.dopplerLevel = 0;
R5.minDistance = 1;
R5.maxDistance = 3;

R6.dopplerLevel = 0;
R6.minDistance = 1;
R6.maxDistance = 3;

Radion = Random.Range(1,6);
}

function Update()
{
Swicht();
Radios();
Tracks();
txtRadio.text = (RadioName + ": " + CurrMusic.name);
}

function Radios()
{
if(Radion == 1)
{
R1.mute = false;
RadioName = R1N;
CurrMusic = R1.clip;
}
else
{
R1.mute = true;
}

if(Radion == 2)
{
R2.mute = false;
RadioName = R2N;
CurrMusic = R2.clip;
}
else
{
R2.mute = true;
}

if(Radion == 3)
{
R3.mute = false;
CurrMusic = R3.clip;
RadioName = R3N;
}
else
{
R3.mute = true;
}

if(Radion == 4)
{
R4.mute = false;
CurrMusic = R4.clip;
RadioName = R4N;
}
else
{
R4.mute = true;
}

if(Radion == 5)
{
R5.mute = false;
CurrMusic = R5.clip;
RadioName = R5N;
}
else
{
R5.mute = true;
}

if(Radion == 6)
{
R6.mute = false;
CurrMusic = R6.clip;
RadioName = R6N;
}
else
{
R6.mute = true;
}
}

function Tracks()
{
if(!R1.isPlaying)
{
R1.clip = _SpecialFM[Random.Range(0,_SpecialFM.length)];
R1.Play();
}
if(!R2.isPlaying)
{
R2.clip = _TrapFM[Random.Range(0,_TrapFM.length)];
R2.Play();
}
if(!R3.isPlaying)
{
R3.clip = _TechnoFM[Random.Range(0,_TechnoFM.length)];
R3.Play();
}
if(!R4.isPlaying)
{
R4.clip = _StreetRaceFM[Random.Range(0,_StreetRaceFM.length)];
R4.Play();
}
if(!R5.isPlaying)
{
R5.clip = _RadioPop[Random.Range(0,_RadioPop.length)];
R5.Play();
}
if(!R6.isPlaying)
{
R6.clip = _SlowFM[Random.Range(0,_SlowFM.length)];
R6.Play();
}
}

function Swicht()
{
Radion = Mathf.Clamp(Radion,1,6);
//Debug.Log("Swicht function in action");
if(Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKeyUp(KeyCode.KeypadMinus))
{
Radion--;
}
if(Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKeyUp(KeyCode.KeypadPlus))
{
Radion++;
}
}
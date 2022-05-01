function OnConnectedToServer() {

var viewID : NetworkViewID= Network.AllocateViewID();
GetComponent.<NetworkView>().RPC("NetwMove", RPCMode.AllBuffered, viewID,transform.position); 

}


@RPC
function NetwMove (viewID : NetworkViewID, location : Vector3) {

var nView : NetworkView;
nView = GetComponent(NetworkView);
nView.viewID = viewID;
}
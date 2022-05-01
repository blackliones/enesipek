using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RemyMoveSc : MonoBehaviour
{
    // Use this for initialization
    Animator anim;
    public Transform silahmp5,silahm4a1;
    public Camera kamera;
    public float tspeed, defaultspeed,fallingzmn,fallingmxzmn;
    public int health;
    public bool isGrounded,fallingbool;
    public Rigidbody rb;
    public bool move, tuswasd, tusarrow, rreload;
    CapsuleCollider cc ;
    public GameObject sarjorelmp5,sarjorsilahmp5,sarjorelm4a1,sarjorsilahm4a1;
    public raycasthit rhscript;
    public Text healthtext;

           public MouseLook ml;
   void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        fallingbool = false;
    }
     
  void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        fallingbool = true;
    }

      void Start()
    {
                anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        move = true;
         cc = GetComponent<CapsuleCollider>();
           defaultspeed = tspeed;
        tuswasd = true;
        tusarrow = false;
        healthtext.text = ""+health;
        sarjorelmp5.SetActive(false);
        sarjorsilahmp5.SetActive(true);
        fallingzmn = fallingmxzmn;
        sarjorelm4a1.SetActive(false);
        sarjorsilahm4a1.SetActive(true);
    }

    // Update is called once per frame
   
    void Update()
    {
        if (fallingbool)
        {
            if (fallingzmn > 0)
                fallingzmn -= Time.deltaTime;
            else if (fallingzmn <= 0)
                           anim.SetBool("falling", true);
        }
        if (isGrounded)
        {
            fallingzmn = fallingmxzmn;
            anim.SetBool("falling", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Jumping");
                rb.velocity = new Vector3(0, 5, 0);
                            
            }
        }
              if (rhscript.gunvalue == 3)
        {
            rhscript.gunname = "mp5";
                }
        else if(rhscript.gunvalue == 2)
        {
            rhscript.gunname = "m4a1";
         }
            else if(rhscript.gunvalue == 1)
        {
            rhscript.gunname = "combatknife";
               }
            if (move)
        {
            if (rhscript.gunname == "mp5")
            {
                silahmp5.transform.eulerAngles = new Vector3(kamera.transform.eulerAngles.x, transform.eulerAngles.y, 0);
                if (rreload)
                {
                    anim.SetBool("Reload", true);
                    sarjorelmp5.SetActive(true);
                    sarjorsilahmp5.SetActive(false);
                    tspeed = defaultspeed;
                }
                else
                {
                    anim.SetBool("Reload", false);
                    sarjorelmp5.SetActive(false);
                    sarjorsilahmp5.SetActive(true);
                   
                }
            }
            else if (rhscript.gunname == "m4a1")
                        {
                          if (rreload)
                {
                    anim.SetBool("Reload", true);
                    sarjorelm4a1.SetActive(true);
                    sarjorsilahm4a1.SetActive(false);
                    tspeed = defaultspeed;
                }
                else
                {
                    anim.SetBool("Reload", false);
                    sarjorelm4a1.SetActive(false);
                    sarjorsilahm4a1.SetActive(true);
                 
                }
            }
                ml.move = true;

            if (rhscript.gunvalue != 1)
            {
                anim.SetBool("Idle",true);
                anim.SetBool("I_Knife",false);
                if (Input.GetMouseButton(0))
                {

                    if (Input.GetKey(KeyCode.R) || rhscript.ammo <= 0 || rreload || rhscript.gunvalue == 1)
                    {
                        anim.SetBool("gunplay", false);


                    }
                    if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                    {
                        if (rhscript.ates && !rreload)
                        {
                            anim.SetBool("I_Crouch", true);
                            anim.SetBool("gunplay", false);
                        }
                    }
                    else if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
                    {
                        if (rhscript.ates && !rreload && rhscript.gunvalue != 1)
                        {
                            anim.SetBool("gunplay", true);
                            anim.SetBool("I_Crouch", false);
                        }
                                        }

                }
            }
            else if(rhscript.gunvalue == 1)
            {
                anim.SetBool("Idle",false);
                anim.SetBool("I_Knife",true);
                if (Input.GetMouseButton(0))
                {
                                  if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
                    {
                                                 anim.SetBool("knifeplaysagtik", true);
                                                anim.SetBool("knifeplaysoltik",false);
                            anim.SetBool("I_Crouch", false);
                        
                    }
                  else  if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                    {
                        anim.SetBool("I_Crouch", true);
                        anim.SetBool("knifeplaysagtik", false);
                       

                    }

                }
                                     if (Input.GetMouseButton(1))
                {
                    if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
                    {
                                                  anim.SetBool("knifeplaysoltik", true);
                            anim.SetBool("knifeplaysagtik",false);
                            anim.SetBool("I_Crouch", false);
                        
                    }
                    else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                    {
                                                 anim.SetBool("knifeplaysoltik", false);
                            anim.SetBool("I_Crouch", true);
                        
                    }

                }
            }
          if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("knifeplaysagtik", false);
                               anim.SetBool("gunplay", false);

            }
          if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("knifeplaysoltik",false);
                         }
            
                          if (tuswasd)
            {
                tusarrow = false;
                float translation = Input.GetAxis("Verticalwasd") * tspeed;
                float rotation = Input.GetAxis("Horizontalwasd") * tspeed;
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                transform.Translate(rotation, 0, translation);
                            tustuswasd();
            }
                     
           else if (tusarrow)
                            {
                tuswasd = false;
                float translation = Input.GetAxis("Verticalarrow") * tspeed;
                float rotation = Input.GetAxis("Horizontalarrow") * tspeed;
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                transform.Translate(rotation, 0, translation);
                
                tustusarrow();
             
            }
        }
        else if(!move)
        {
            ml.move = false;
        }
           }
    void tustusarrow()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("WF", true);
           

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("WF", false);
           

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("WB", true);
          
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("WB", false);
          
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("RF", true);
          
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightShift))
        {
            anim.SetBool("RF", false);
      
            tspeed = defaultspeed;
        }
        //WALKFORWARD R-L

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("WF_Left", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("WF_Left", false);
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("WF_Right", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("WF_Right", false);
        }
        //------------------------------------------------
        //WALKBACKWARD R-L
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("WB_Left", true);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("WB_Left", false);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("WB_Right", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("WB_Right", false);
                    }
        //-----------------------------------------------
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("RB", true);
            tspeed=6; 
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightShift))
        {
            anim.SetBool("RB", false);
                     tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.RightControl) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("I_Crouch", true);
            cc.height = 2.5f;
            cc.center = new Vector3(0, 1, 0);
        }
        if (Input.GetKeyUp(KeyCode.RightControl) ||Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("I_Crouch", false);
            cc.height = 3.9f;
            cc.center = new Vector3(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("WCF", true);
        }
        if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("WCF", false);
        }
        if (Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("WCB", true);
        }
        if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("WCB", false);
        }
                  if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("W_Left", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("W_Left", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("W_Right", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("W_Right", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightControl))
        {
            anim.SetBool("C_Left", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightControl))
        {
            anim.SetBool("C_Left", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.RightControl))
        {
            anim.SetBool("C_Right", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightControl))
        {
            anim.SetBool("C_Right", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("R_Left", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightShift))
        {
            anim.SetBool("R_Left", false);
            tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("R_Right", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightShift))
        {
            anim.SetBool("R_Right", false);
            tspeed = defaultspeed;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("RF_Left", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("RF_Left", false);
            tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("RF_Right", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("RF_Right", false);
            tspeed = defaultspeed;
        }
    }
   
    void tustuswasd()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("WF", true);
           

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("WF", false);
         

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("WB", true);
            tspeed = 4;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("WB", false);
            tspeed = defaultspeed;
         
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("RF", true);
            tspeed=8;
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("RF", false);

            tspeed = defaultspeed;
        }//RunForward R-L

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)&&Input.GetKey(KeyCode.A))
        {
            anim.SetBool("RF_Left", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("RF_Left",false);
            tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("RF_Right", true);
            tspeed =6f;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("RF_Right", false);
            tspeed = defaultspeed;
        }
        //WALKFORWARD R-L
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("WF_Left",true);
                    }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("WF_Left", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("WF_Right", true);
                  }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("WF_Right", false);
        }//WALKBACKWARD R-L
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("WB_Left", true);
          
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("WB_Left", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("WB_Right", true);
                  }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("WB_Right", false);
        }
      
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("RB", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("RB", false);
            tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("I_Crouch", true);
                      cc.height = 2.5f;
            cc.center=new Vector3(0,1,0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) ||Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("I_Crouch", false);
            cc.height = 3.9f;
            cc.center = new Vector3(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("WCF", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("WCF", false);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
        {
            anim.SetBool("WCB", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("WCB", false);
        }
            if (Input.GetKey(KeyCode.A)&&!Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("W_Left", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("W_Left", false);
        }
        if (Input.GetKey(KeyCode.D)&&!Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("W_Right", true);
        }
        if (Input.GetKeyUp(KeyCode.D)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            anim.SetBool("W_Right", false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("C_Left", true);
      
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("R_Left",true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("R_Left",false);
            tspeed = defaultspeed;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("R_Right", true);
            tspeed=6;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("R_Right", false);
            tspeed = defaultspeed;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("C_Left", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("C_Right", true);
         }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("C_Right", false);
        }
    }
       }
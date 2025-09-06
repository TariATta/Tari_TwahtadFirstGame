using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlashLightBindingDoor
{
    public class OpenCloseDoor_FlashlightBinding : MonoBehaviour
    {
		public Animator openandclose;
		public bool open;
		public Transform Player;

		public AudioSource Opendoorsound;
		public AudioSource Closedoorsound;

        [SerializeField] private FlashlightInventory _flashlightInventory;

		void Start()
		{
			open = false;
			Opendoorsound = GetComponent<AudioSource>();
			Closedoorsound = GetComponent<AudioSource>();
		}

		void OnMouseOver()
		{
			
				if (Player)
				{

					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 3)
					{
						if (_flashlightInventory.hasFlashLight == true)
						{
							if (open == false)
							{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
								Opendoorsound.Play();

								}
							}
							else
							{
								if (open == true)
								{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
									Closedoorsound.Play();

									}
								}

							}
						}

					}
                    

				}

		}


		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			_flashlightInventory.hasFlashLight = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			_flashlightInventory.hasFlashLight = true;
			yield return new WaitForSeconds(.5f);
		}

	}
}


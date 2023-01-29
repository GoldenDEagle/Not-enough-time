using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SojaExiles

{
	public class opencloseWindow1 : MonoBehaviour
	{

		public Animator openandclosewindow1;
		public bool open;

        private Transform Player;

        [SerializeField] private InputActionReference _interactionControl;

        private void OnEnable()
        {
            _interactionControl.action.Enable();
        }

        private void OnDisable()
        {
            _interactionControl.action.Disable();
        }

        void Start()
		{
			open = false;
            Player = GameObject.FindWithTag("Player").transform;
        }

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{
						if (open == false)
						{
							if (_interactionControl.action.triggered)
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (_interactionControl.action.triggered)
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the Window");
			openandclosewindow1.Play("Openingwindow 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandclosewindow1.Play("Closingwindow 1");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
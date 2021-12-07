using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Siccity.GLTFUtility;
namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
      
        public UnityEvent onContentPlaced;

        private List<GameObject> prefabs = new List<GameObject>();

        public Text debugLog;
        public bool canAugment = false;
        public Animator animator;
        private int modelId;
        private int placedPrefabCount;
        public GameObject TakeImageButton;
        public GameObject Featheredplane;
        public ModelLoader ModelLoader;
        public GameObject shadowPlane;
        bool isShadowPlaneAugmented=false;
        public GameObject AddButton;
        public ARPlaneManager m_ARPlaneManager;

        
        public static PlaceOnPlane instance;

        public bool IsModelLoaded(int id)
        {
            foreach (GameObject prefab in prefabs)
            {
                if (prefab.GetComponent<ObjectSelection>().id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddItemToList(GameObject item,int id)
        {
            foreach (GameObject prefab in prefabs)
            {
                if (prefab.GetComponent<ObjectSelection>().id == id)
                {
                    return;
                }
            }
            prefabs.Add(item);
        }

        public void EnableTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(true);
           
        }
        public void DisbleTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(false);
          
        }

        public GameObject spawnedObject { get; private set; }

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_ARPlaneManager = GetComponent<ARPlaneManager>();
            DisbleTracking();

                if (instance != null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    instance = this;
                }
            
        }
        
        public void SelectModel(int id)
        {
            modelId = id;
            debugLog.text = "Tap to place new Model!";
            animator.SetTrigger("Down");
            Invoke(nameof(TurnAugmentation), 1.0f);
            TakeImageButton.SetActive(false);
            EnableTracking();
        }
        void TurnAugmentation()
        {
            canAugment = true;
        }
        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
    #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
    #else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
    #endif

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;
                
                if(canAugment)
                {
                    if (!isShadowPlaneAugmented)
                    {
                        Instantiate(shadowPlane, hitPose.position, hitPose.rotation);
                        isShadowPlaneAugmented = true;
                    }

                    GameObject result;
                    foreach (GameObject prefab in prefabs)
                    {
                        if (prefab.GetComponent<ObjectSelection>().id == modelId)
                        {
                            result = Instantiate(prefab, hitPose.position, hitPose.rotation);
                            result.SetActive(true);
                        }
                    }
                    
                    
                    canAugment = false;
                    
                    onContentPlaced.Invoke();
                    Handheld.Vibrate();
                    AddButton.SetActive(true);
                   
                    debugLog.text = "Select Model!";
                    TakeImageButton.SetActive(true);
                    DisbleTracking();
                    
                }
                
            }
            
        }
        

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
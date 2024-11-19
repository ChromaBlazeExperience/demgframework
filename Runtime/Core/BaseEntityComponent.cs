using UnityEngine;

namespace DemGFramework.Core
{
    public class BaseEntityComponent<T, Y> : MonoBehaviour {
        protected T data;
        protected Y state;
        public bool readyToWork = false;
        public bool canPlay = false;

        #region UNITY EVENTS
            public void _Destroy(GameObject obj)
            {
                Destroy(obj);
            }
            public GameObject _Instantiate(GameObject obj, Vector3 position, Quaternion rotation)
            {
                return Instantiate(obj, position, rotation);
            }
        #endregion

        #region SETTERS
            public void SetState(Y state) {
                this.state = state;
            }
            public virtual void Initialize(T data, Y state, object extra = null) {
                SetState(state);
                SetScriptableObject(data);
                LoadFromData();
            }
            public virtual void LoadNewData(T data) {
                SetScriptableObject(data);
                LoadFromData();
            }
            public virtual void SetScriptableObject(T data) {
                this.data = data;
            }
            public virtual void LoadFromData() {
                if(!readyToWork) SetupComponent();
            }
            public virtual void ReadyToWork() {
                readyToWork = true;
            }
            public virtual void SetCanPlay(bool value) {
                canPlay = value;
            }
        #endregion

        #region LIFECYCLE
            public virtual void SetupComponent() {
                ReadyToWork();
            }
            public virtual void StartComponent() {

            }
        #endregion
    }
}
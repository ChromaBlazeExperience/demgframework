using System.Collections.Generic;
using UnityEngine;

using Data = System.Collections.Generic.Dictionary<string, object>;

namespace DemGFramework.Core
{
    public class BaseEntityComponent<State> : MonoBehaviour {
        protected Dictionary<string, object> data;
        protected State state;
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
            public void SetState(State state) {
                this.state = state;
            }
            public virtual void Initialize(Data data, State state, object extra = null) {
                SetState(state);
                SetNewData(data);
                LoadFromData();
            }
            public virtual void LoadNewData(Data data) {
                SetNewData(data);
                LoadFromData();
            }
            public virtual void SetNewData(Data data) {
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
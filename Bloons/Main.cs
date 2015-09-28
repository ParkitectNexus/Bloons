using UnityEngine;

namespace Bloons
{
    public class Main : IMod
    {
        private GameObject _gameObject;

        #region Implementation of IMod

        public void onEnabled()
        {
            if (_gameObject != null)
                return;

            _gameObject = new GameObject();
            _gameObject.AddComponent<Bloons>();
        }

        public void onDisabled()
        {
            Object.Destroy(_gameObject);
            _gameObject = null;
        }

        public string Name
        {
            get { return "Bloons"; }
        }

        public string Description
        {
            get { return "Allows you to pop balloons!"; }
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DemGFramework.Core {

    [CreateAssetMenu(fileName = "ObjectExample", menuName = "EntitySettings/ObjectExample", order = 1)]
    public class ObjectExample : BaseDataObject {
    
        public Prova prova;

        public ObjectExample() {
            prova = new Prova();
            prova.nome = "ciao";
            prova.eta = 12;

            var a = Utility.Utility.ToDictionary(prova);
            Debug.Log(a.ElementAt(0).Key + " " + a.ElementAt(0).Value);
            Debug.Log(a.ElementAt(1).Key + " " + a.ElementAt(1).Value);

        }
    }

    public struct Prova {

        public string nome;
        public int eta;

    }

}
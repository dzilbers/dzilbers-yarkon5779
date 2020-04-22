using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinTree;

namespace BinTreeCorona
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static bool IsLeaf<T>(BinNode<T> node)
        {
            return !node.HasLeft() && !node.HasRight();
        }


        // Targil 2

        // Help function to check dead descendants
        private static bool DeadDescendants(BinNode<Patient> patient)
        {
            if (IsLeaf(patient)) return false;
            if (patient.HasLeft() &&
                (patient.GetLeft().GetValue().GetDead() || DeadDescendants(patient.GetLeft()))
               )
                return true;
            if (patient.HasRight() &&
                (patient.GetRight().GetValue().GetDead() || DeadDescendants(patient.GetRight()))
               )
                return true;
            return true;
        }

        public static int DeadlyDistributor(BinNode<Patient> patient)
        {
            if (patient == null || IsLeaf(patient)) return 0;
            if (DeadDescendants(patient))
                return 1 + DeadlyDistributor(patient.GetLeft()) + DeadlyDistributor(patient.GetRight());
            else
                return DeadlyDistributor(patient.GetLeft()) + DeadlyDistributor(patient.GetRight());
        }

        private static BinNode<Patient> Find(BinNode<Patient> patient, int id)
        {
            BinNode<Patient> temp;
            if (patient == null) return null;
            if (patient.GetValue().GetId() == id) return patient;
            temp = Find(patient.GetLeft(), id);
            if (temp != null) return temp;
            temp = Find(patient.GetRight(), id);
            if (temp != null) return temp;
            return null;
        }

        private static bool CheckInfected(BinNode<Patient> patient, int id)
        {
            return (patient.HasLeft() && patient.GetLeft().GetValue().GetId() == id) ||
                (patient.HasRight() && patient.GetRight().GetValue().GetId() == id);
        }

        public static int Targil3(BinNode<Patient> patient, BinNode<int> parent)
        {
            if (parent == null || IsLeaf(parent)) return 0;
            BinNode<Patient> parentPatient = Find(patient, parent.GetValue());
            
            if (parentPatient == null)
                return Targil3(patient, parent.GetLeft()) + Targil3(patient, parent.GetRight());

            if ((parent.HasLeft() && CheckInfected(parentPatient, parent.GetLeft().GetValue())) ||
                (parent.HasRight() && CheckInfected(parentPatient, parent.GetRight().GetValue())))
                return 1 + Targil3(patient, parent.GetLeft()) + Targil3(patient, parent.GetRight());
            else
                return Targil3(patient, parent.GetLeft()) + Targil3(patient, parent.GetRight());
        }

    }
}

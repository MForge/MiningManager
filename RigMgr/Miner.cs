using System;

namespace MiningManager
{
    public class Miner
    {
        private string m_name;
        private string m_path;
        private int m_order;
        private Boolean m_isSelected;

        public Miner()
        {
            m_name = "";
            m_path = "";
            m_order = 0;
            m_isSelected = false;
        }

        public Miner(string aName, string aPath, int aOrde, Boolean aIsSelected)
        {
            m_name = aName;
            m_path = aPath;
            m_order = aOrde;
            m_isSelected = aIsSelected;
        }

        public Miner(string aName, string aPath)
        {
            m_name = aName;
            m_path = aPath;
            m_order = 0;
            m_isSelected = false;
        }

        public override int GetHashCode()
        {
            return m_order;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Miner objAsClientDaoc = obj as Miner;
            if (objAsClientDaoc == null) return false;
            else return Equals(objAsClientDaoc);
        }

        public bool Equals(Miner other)
        {
            if (other == null) return false;
            return (this.m_order.Equals(other.m_order));
        }

        public int SortByOrdeAscending(int order1, int order2)
        {
            return order1.CompareTo(order2);
        }

        public int CompareTo(Miner compareMiner)
        {
            if (compareMiner == null)
                return 1;
            else
                return this.m_order.CompareTo(compareMiner.m_order);
        }

        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }

        public string Path
        {
            get
            {
                return m_path;
            }

            set
            {
                m_path = value;
            }
        }

        public int Order
        {
            get
            {
                return m_order;
            }

            set
            {
                m_order = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return m_isSelected;
            }

            set
            {
                m_isSelected = value;
            }
        }
    }
}

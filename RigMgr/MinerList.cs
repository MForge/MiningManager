using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiningManager
{
    public class MinerList : IEnumerable
    {
        private List<Miner> m_MinerList = new List<Miner>();

        public void add(Miner aMiner)
        {
            try
            {
                m_MinerList.Add(aMiner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delete(Miner aClientDaoc)
        {
            try
            {
                if (m_MinerList.Contains(aClientDaoc))
                {
                    m_MinerList.Remove(aClientDaoc);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delete(string aName, string aPath)
        {
            try
            {
                foreach (Miner aMiner in m_MinerList)
                {
                    if (aMiner.Name == aName && aMiner.Path == aPath)
                    {
                        m_MinerList.Remove(aMiner);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool getMinerByName(string aName, out Miner theMiner)
        {
            bool toReturn = false;
            theMiner = new Miner();
            foreach (Miner m in m_MinerList)
            {
                if (m.Name == aName)
                {
                    toReturn = true;
                    theMiner = m;
                    break;
                }
            }

            return toReturn;
        }

        public void Sort()
        {
            m_MinerList = m_MinerList.OrderBy(o => o.Order).ToList();
        }

        public void clear()
        {
            m_MinerList.Clear();
        }

        public int count()
        {
            return m_MinerList.Count();
        }

        public Miner getMiner(int index)
        {
            return m_MinerList[index];
        }

        public bool content(string aName, string aPath)
        {
            bool toReturn = false;
            foreach (Miner m in m_MinerList)
            {
                if (m.Name == aName && m.Path == aPath)
                {
                    toReturn = true;
                    break;
                }
            }
            return toReturn;
        }

        #region implémentation IEnumerable

        public MinerEnumerator GetEnumerator() // non-IEnumerable version
        {
            return new MinerEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() // IEnumerable version
        {
            return (IEnumerator)new MinerEnumerator(this);
        }

        //************************************************************************
        //****************** Classe d'Iteration **********************************
        //************************************************************************

        public class MinerEnumerator : IEnumerator
        {
            private int position = -1;
            private MinerList t;

            public MinerEnumerator(MinerList t)
            {
                this.t = t;
            }

            public bool MoveNext()
            {
                if (position < t.count() - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public Miner Current // non-IEnumerator version: type-safe
            {
                get
                {
                    return t.getMiner(position);
                }
            }

            object IEnumerator.Current // IEnumerator version: returns object
            {
                get
                {
                    return t.getMiner(position);
                }
            }
        }

        //************************************************************************
        //************************************************************************
        //************************************************************************

        #endregion implémentation IEnumerable
    }
}

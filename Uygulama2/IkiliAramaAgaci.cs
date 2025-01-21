using System;

namespace Uygulama2
{
    public class IkiliAramaAgaciDugumu
    {
        public int veri { get; private set; }
        public IkiliAramaAgaciDugumu sol;
        public IkiliAramaAgaciDugumu sag;

        public IkiliAramaAgaciDugumu(int veri)
        {
            this.veri = veri;
        }
        public void SetSol(IkiliAramaAgaciDugumu sol)
        {
            this.sol = sol;
        }
        public void SetSag(IkiliAramaAgaciDugumu sag)
        {
            this.sag = sag;
        }
    }
    public class IkiliAramaAgaci
    {
        private IkiliAramaAgaciDugumu kok;

        public void Ekle(int veri)
        {
            if (!Arama(kok, veri))
                kok = EkleRec(kok, veri);
        }
        private IkiliAramaAgaciDugumu EkleRec(IkiliAramaAgaciDugumu dugum, int veri)
        {
            if (dugum == null)
            {
                dugum = new IkiliAramaAgaciDugumu(veri);
                return dugum;
            }

            if (dugum.veri < veri)
            {
                dugum.sag = EkleRec(dugum.sag, veri);
            }
            else if (dugum.veri > veri)
            {
                dugum.sol = EkleRec(dugum.sol, veri);
            }

            return dugum;
        }
        public void InOrder()
        {
            InOrderRec(kok);
        }
        private void InOrderRec(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum != null)
            {
                InOrderRec(dugum.sol);
                Console.Write(dugum.veri + " ");
                InOrderRec(dugum.sag);
            }
        }
        public void PreOrder()
        {
            PreOrderRec(kok);
        }
        private void PreOrderRec(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum != null)
            {
                Console.Write(dugum.veri + " ");
                PreOrderRec(dugum.sol);
                PreOrderRec(dugum.sag);
            }
        }
        public void PostOrder()
        {
            PostOrderRec(kok);
        }
        private void PostOrderRec(IkiliAramaAgaciDugumu dugum)
        {
            if (dugum != null)
            {
                PostOrderRec(dugum.sol);
                PostOrderRec(dugum.sag);
                Console.Write(dugum.veri + " ");
            }
        }
        public bool Arama(IkiliAramaAgaciDugumu dugum, int veri)
        {
            if (dugum == null)
                return false;

            if (dugum.veri == veri)
                return true;

            if (dugum.veri < veri)
                return Arama(dugum.sol, veri);
            else
                return Arama(dugum.sag, veri);
        }
    }
}

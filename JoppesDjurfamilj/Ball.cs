using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Ball {
        private string color = "";
        private string texture = "";
        private int size = 6;
        private int quality = 0;
        public static int maxQuality = 30;

        public string Color {
            get { return color; }
            set { color = value; }
        }

        public string Texture {
            get { return texture; }
            set { texture = value; }
        }

        public int Size {
            get { return size; }
            set { size = value; }
        }

        public int Quality {
            get { return quality; }
            set { quality = value; }
        }

        public Ball(string _color, string _texture, int _size, int _quality) {
            color = _color;
            texture = _texture;
            size = _size;
            quality = _quality;

        }

        public string QualityString() {
            return $"{Quality}/{maxQuality}";
        }

        public override string ToString() {
            return $"{color}, {texture} ball";
        }

    }
}

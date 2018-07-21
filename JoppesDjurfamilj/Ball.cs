using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Ball {
        private string color = "";
        private string texture = "";
        private int size = 5;
        private int quality = 30;

        public string Color {
            get { return color; }
            set { value = color; }
        }

        public string Texture {
            get { return texture; }
            set { value = texture; }
        }

        public int Size {
            get { return size; }
            set { value = size; }
        }

        public int Quality {
            get { return quality; }
            set { value = quality; }
        }

        public Ball(string _color, string _texture, int _size, int _quality) {
            color = _color;
            texture = _texture;
            size = _size;
            quality = _quality;

        }
    }
}

namespace CSharpPractice.DesignPatterns.StructuralPatterns.Flyweight
{
    public class BulletType
    {
        public string Sprite { get; }
        public string Color { get; }
        public int Damage { get; }

        public BulletType(string sprite, string color, int damage) 
        {
            Sprite = sprite;
            Color = color;
            Damage = damage;
        }

        public void Draw(int x, int y, int velocity)
        {
            Console.WriteLine($"Drawing bullet [{Sprite}, {Color}, Damage: {Damage}] at ({x},{y}) with velocity {velocity}");
        }
    }

    public class BulletFactory
    {
        private readonly Dictionary<string, BulletType> _bulletTypes = new();

        public BulletType GetBulletType(string sprite, string color, int damage)
        {
            string key = $"{sprite}_{color}_{damage}";
            if (!_bulletTypes.TryGetValue(key, out var bulletType))
            {
                bulletType = new BulletType(sprite, color, damage);
                _bulletTypes[key] = bulletType;
            }
            return bulletType;
        }
    }

    public class Bullet
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _velocity;
        private readonly BulletType _type;

        public Bullet(int x, int y, int velocity, BulletType type)
        {
            _x = x;
            _y = y;
            _velocity = velocity;
            _type = type;
        }

        public void Draw()
        {
            _type.Draw(_x, _y, _velocity);
        }
    }

    public class FlyweightClient
    {
        public static void Test()
        {
            var factory = new BulletFactory();

            var bullets = new List<Bullet>
            {
                new Bullet(10, 20, 5, factory.GetBulletType("Round", "Red", 10)),
                new Bullet(15, 25, 5, factory.GetBulletType("Round", "Red", 10)),
                new Bullet(30, 40, 7, factory.GetBulletType("Laser", "Blue", 20)),
                new Bullet(59, 60, 7, factory.GetBulletType("Laser", "Blue", 20)),
            };

            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }
        }
    }
}

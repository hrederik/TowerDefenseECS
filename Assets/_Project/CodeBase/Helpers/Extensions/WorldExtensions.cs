using Leopotam.Ecs;

namespace Helpers.Extensions
{
    public static class WorldExtensions
    {
        public static void Message<T>(this EcsWorld world, T request) where T : struct
        {
            world.NewEntity().Get<T>() = request;
        }
    }
}
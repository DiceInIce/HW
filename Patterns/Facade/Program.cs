using System;

namespace HomeTheater
{
    public class Amplifier
    {
        public void On() => Console.WriteLine("Усилитель включен");
        public void Off() => Console.WriteLine("Усилитель выключен");
        public void SetVolume(int level) => Console.WriteLine($"Громкость усилителя установлена на {level}");
        public void SetSurroundSound() => Console.WriteLine("Усилитель: включён объемный звук");
        public void SetStereoSound() => Console.WriteLine("Усилитель: включён стерео звук");
    }

    public class Tuner
    {
        public void On() => Console.WriteLine("Тюнер включен");
        public void Off() => Console.WriteLine("Тюнер выключен");
        public void SetFrequency(double frequency) => Console.WriteLine($"Тюнер настроен на частоту {frequency} МГц");
    }

    public class BluRayPlayer
    {
        public void On() => Console.WriteLine("Blu-ray проигрыватель включен");
        public void Off() => Console.WriteLine("Blu-ray проигрыватель выключен");
        public void Play(string movie) => Console.WriteLine($"Начато воспроизведение фильма \"{movie}\"");
        public void Stop() => Console.WriteLine("Воспроизведение остановлено");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Проектор включен");
        public void Off() => Console.WriteLine("Проектор выключен");
        public void SetWideScreenMode() => Console.WriteLine("Проектор: режим широкого экрана (16x9)");
        public void SetTvMode() => Console.WriteLine("Проектор: режим ТВ");
    }

    public class TheaterLights
    {
        public void On() => Console.WriteLine("Освещение включено");
        public void Off() => Console.WriteLine("Освещение выключено");
        public void Dim(int level) => Console.WriteLine($"Освещение приглушено до {level}%");
    }

    public class Screen
    {
        public void Up() => Console.WriteLine("Экран поднят");
        public void Down() => Console.WriteLine("Экран опущен");
    }

    public class PopcornPopper
    {
        public void On() => Console.WriteLine("Попкорн-машина включена");
        public void Off() => Console.WriteLine("Попкорн-машина выключена");
        public void Pop() => Console.WriteLine("Попкорн готовится");
    }

    public class HomeTheaterFacade
    {
        private Amplifier amplifier;
        private Tuner tuner;
        private BluRayPlayer player;
        private Projector projector;
        private TheaterLights lights;
        private Screen screen;
        private PopcornPopper popper;

        public HomeTheaterFacade(Amplifier amplifier, Tuner tuner, BluRayPlayer player,
                                 Projector projector, TheaterLights lights, Screen screen, PopcornPopper popper)
        {
            this.amplifier = amplifier;
            this.tuner = tuner;
            this.player = player;
            this.projector = projector;
            this.lights = lights;
            this.screen = screen;
            this.popper = popper;
        }

        public void WatchMovie(string movieName)
        {
            Console.WriteLine("\nПодготовка к просмотру фильма...");
            popper.On();
            popper.Pop();

            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.SetWideScreenMode();

            amplifier.On();
            amplifier.SetSurroundSound();
            amplifier.SetVolume(5);

            player.On();
            player.Play(movieName);
            Console.WriteLine("Фильм запущен. Приятного просмотра!\n");
        }

        public void EndMovie()
        {
            Console.WriteLine("\nЗавершение просмотра фильма...");
            player.Stop();
            player.Off();
            amplifier.Off();
            projector.Off();
            screen.Up();
            lights.On();
            popper.Off();
            Console.WriteLine("Просмотр фильма завершен.\n");
        }

        public void ListenToRadio(double frequency)
        {
            Console.WriteLine("\nПодготовка к прослушиванию радио...");
            tuner.On();
            tuner.SetFrequency(frequency);
            amplifier.On();
            amplifier.SetStereoSound();
            amplifier.SetVolume(3);
            Console.WriteLine("Радио включено.\n");
        }

        public void EndRadio()
        {
            Console.WriteLine("\nЗавершение прослушивания радио...");
            tuner.Off();
            amplifier.Off();
            Console.WriteLine("Радио выключено.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner();
            BluRayPlayer player = new BluRayPlayer();
            Projector projector = new Projector();
            TheaterLights lights = new TheaterLights();
            Screen screen = new Screen();
            PopcornPopper popper = new PopcornPopper();

            Console.WriteLine("---------------------------\n Работа системы без фасада\n--------------------------- ");
            popper.On();
            popper.Pop();
            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.SetWideScreenMode();
            amp.On();
            amp.SetSurroundSound();
            amp.SetVolume(5);
            player.On();
            player.Play("Начало");

            player.Stop();
            player.Off();
            amp.Off();
            projector.Off();
            screen.Up();
            lights.On();
            popper.Off();

            Console.WriteLine("---------------------------\n Работа системы c фасадом\n--------------------------- ");
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amp, tuner, player, projector, lights, screen, popper);
            homeTheater.WatchMovie("Интерстеллар");
            homeTheater.EndMovie();

            homeTheater.ListenToRadio(101.1);
            homeTheater.EndRadio();

            Console.WriteLine("Работа программы завершена.");
        }
    }
}
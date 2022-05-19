using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface ITheme
    {
        string TextColor{ get; }
        string BgrColor{ get; }
    }

    public class LightTheme : ITheme
    {
        public string TextColor => "black";
        public string BgrColor => "white";
    }

    public class DarkTheme : ITheme
    {
        public string TextColor => "white";
        public string BgrColor => "dark grey";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themes = new List<WeakReference<ITheme>>();

        public ITheme CreateTheme(bool dark)
        {
            ITheme theme;
            if (dark)
                theme = new DarkTheme();
            else
                theme = new LightTheme();

            themes.Add(new WeakReference<ITheme>(theme));

            return theme;
        }

        public string Info
        {
            get
            {
                var sb= new StringBuilder();
                foreach(var reference in themes)
                {
                    if(reference.TryGetTarget(out var theme))
                    {
                        bool dark = theme is DarkTheme;
                        sb.Append(dark ? "Dark" : "Light")
                            .AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes = new List<WeakReference<Ref<ITheme>>>();

        private ITheme createThemeImpl(bool dark)
        {
            if (dark)
                return new DarkTheme();
            else
                return new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            themes.Add(new WeakReference<Ref<ITheme>>(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in themes)
            {
                if(wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value { get; set; }

        public Ref(T value)
        {
            Value = value;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace Xamarin.Forms {

//	public class FormsStyles {
//		public static string Generate ()
//		{
//			var views = typeof (VisualElement).Assembly.GetTypes ().Where (type => type.IsSubclassOf (typeof (VisualElement))).ToList ();
//			(Type type, string ClassName, string SubclassName, List<(string Property, PropertyInfo Type)>) GenerateData (Type v, string baseClassName = null)
//			{
//				var bindableProps = v.GetFields (BindingFlags.Public | BindingFlags.Static).Where (x => x.FieldType == typeof (BindableProperty)).ToList ();
//				var props = v.GetProperties (BindingFlags.Public | BindingFlags.Instance);
//				var combinations = bindableProps.Where (x => x.DeclaringType == v).Select (x => (Property: x, Type: props.FirstOrDefault (p => p.Name == x.Name.Replace ("Property", "")))).ToList ();
//				var cleaned = combinations.Where (x => x.Type != null).Select (x => (Property: $"{x.Property.DeclaringType.Name}.{x.Property.Name}", Type: x.Type)).ToList ();
//				if (baseClassName == null)
//					baseClassName = $"{v.BaseType.Name}Style";
//				return (v, $"{v.Name}Style", baseClassName, cleaned);
//			}
//			var classes = new List<(Type type, string ClassName, string BaseClassName, List<(string Property, PropertyInfo Type)> Properties)> ();
//			classes.Add (GenerateData (typeof (VisualElement), "StyleHelper"));
//			views.ForEach (x => classes.Add (GenerateData (x)));

//			var sb = new StringBuilder ();
//			sb.AppendLine ("using System;");
//			sb.AppendLine ("namespace Xamarin.Forms {");
//			sb.AppendLine ("");
//			foreach (var c in classes) {
//				if (c.Properties.Count == 0)
//					continue;
//				if (c.type.IsGenericType)
//					continue;
//				sb.AppendLine ($"public class {c.ClassName} : {c.BaseClassName} {{");
//				sb.AppendLine ($"public {c.ClassName}() {{Type = typeof({c.type.Name}); }}");
//				foreach (var prop in c.Properties) {
//					sb.AppendLine ($"public {prop.Type.PropertyType} {prop.Type.Name} {{");
//					sb.AppendLine ($"get => GetValue<{prop.Type.PropertyType}> ({prop.Property});");
//					sb.AppendLine ($"set => SetValue({prop.Property}, value);");
//					sb.AppendLine ("}");
//				}
//				sb.AppendLine ("}");
//			}
//			sb.AppendLine ("}");
//			sb.AppendLine ("");
//			var s = sb.ToString ();
//			return sb.ToString ();
//		}
//	}

//	public class StyleHelper {
//		public string Name { get; set; }
//		protected Type Type;
//		public readonly Dictionary<BindableProperty, object> Properties = new Dictionary<BindableProperty, object> ();
//		public Style ToStyle ()
//		{
//			if (Type == null)
//				throw new Exception ("Please set the Type first");
//			return Apply (new Style (Type));
//		}
//		public Style Apply (Style style)
//		{
//			Properties.ForEach (x => style.Setters.Add (new Setter { Property = x.Key, Value = x.Value }));
//			return style;
//		}

//		public static implicit operator Style (StyleHelper s) => s.ToStyle ();

//		protected T GetValue<T> (BindableProperty property) => Properties.TryGetValue (property, out var val) ? (T)val : default (T);
//		protected void SetValue (BindableProperty prop, object value) => Properties [prop] = value;
//	}
//}

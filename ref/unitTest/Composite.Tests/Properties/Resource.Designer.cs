﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarvellousWorks.PracticalPattern.Composite.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarvellousWorks.PracticalPattern.Composite.Tests.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;composite name=&quot;corporate&quot;&gt;
        ///  &lt;leaf name=&quot;president&quot;/&gt;
        ///  &lt;leaf name=&quot;vice president&quot;/&gt;
        ///  &lt;composite name=&quot;market&quot;&gt;
        ///    &lt;leaf name=&quot;judi&quot;/&gt;
        ///  &lt;/composite&gt;
        ///  &lt;composite name=&quot;sales&quot;&gt;
        ///    &lt;leaf name=&quot;joe&quot;/&gt;
        ///    &lt;leaf name=&quot;bob&quot;/&gt;
        ///  &lt;/composite&gt;
        ///  &lt;composite name=&quot;branch&quot;&gt;
        ///    &lt;leaf name=&quot;manager&quot;/&gt;
        ///    &lt;leaf name=&quot;peter&quot;/&gt;
        ///  &lt;/composite&gt;
        ///&lt;/composite&gt;.
        /// </summary>
        internal static string CorporateRaw {
            get {
                return ResourceManager.GetString("CorporateRaw", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;corporate&gt;
        ///  &lt;president/&gt;
        ///  &lt;vicePresident/&gt;
        ///  &lt;department name=&quot;market&quot;&gt;
        ///    &lt;employee name=&quot;judi&quot;/&gt;
        ///  &lt;/department&gt;
        ///  &lt;department name=&quot;sales&quot;&gt;
        ///    &lt;employee name=&quot;joe&quot;/&gt;
        ///    &lt;employee name=&quot;bob&quot;/&gt;
        ///  &lt;/department&gt;
        ///  &lt;branch&gt;
        ///    &lt;manager/&gt;
        ///    &lt;employee name=&quot;peter&quot;/&gt;
        ///  &lt;/branch&gt;
        ///&lt;/corporate&gt;.
        /// </summary>
        internal static string CorporateV1 {
            get {
                return ResourceManager.GetString("CorporateV1", resourceCulture);
            }
        }
    }
}

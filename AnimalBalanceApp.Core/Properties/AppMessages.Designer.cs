﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimalBalanceApp.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AnimalBalanceApp.Core.Properties.AppMessages", typeof(AppMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El correo electronico es invalido.
        /// </summary>
        public static string EmailInvalid {
            get {
                return ResourceManager.GetString("EmailInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El correo Electronico es requerido.
        /// </summary>
        public static string EmailRequired {
            get {
                return ResourceManager.GetString("EmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Credentials.
        /// </summary>
        public static string InvalidCredencial {
            get {
                return ResourceManager.GetString("InvalidCredencial", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El Usuario debe tener más de 13 años.
        /// </summary>
        public static string InvalidUserAge {
            get {
                return ResourceManager.GetString("InvalidUserAge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid characters in the user last name.
        /// </summary>
        public static string LastNameInvalidCharacteres {
            get {
                return ResourceManager.GetString("LastNameInvalidCharacteres", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El parametro de entrada esta herrado.
        /// </summary>
        public static string MessageParameter {
            get {
                return ResourceManager.GetString("MessageParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid characters in the user name.
        /// </summary>
        public static string NameInvalidCharacters {
            get {
                return ResourceManager.GetString("NameInvalidCharacters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0 minutes.
        /// </summary>
        public static string NumberMinutosToken {
            get {
                return ResourceManager.GetString("NumberMinutosToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La contraseña ingresada no coincide.
        /// </summary>
        public static string PasswordNotMatch {
            get {
                return ResourceManager.GetString("PasswordNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Se actualizo la contraseña exitosamente.
        /// </summary>
        public static string PasswordUpdateSuccess {
            get {
                return ResourceManager.GetString("PasswordUpdateSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario registrado exitosamente.
        /// </summary>
        public static string RegisterUser {
            get {
                return ResourceManager.GetString("RegisterUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario eliminado exitosamente.
        /// </summary>
        public static string UserDeletSuccess {
            get {
                return ResourceManager.GetString("UserDeletSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El usuario consultado no existe.
        /// </summary>
        public static string UserNotExists {
            get {
                return ResourceManager.GetString("UserNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Información del usuario actualizada exitosamente.
        /// </summary>
        public static string UserUpdateSuccess {
            get {
                return ResourceManager.GetString("UserUpdateSuccess", resourceCulture);
            }
        }
    }
}
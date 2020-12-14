
import 'package:intl/intl.dart';

class AndroidAuthMessages {
  const AndroidAuthMessages({
    this.fingerprintHint,
    this.fingerprintNotRecognized,
    this.fingerprintSuccess,
    this.cancelButton,
    this.signInTitle,
    this.fingerprintRequiredTitle,
    this.goToSettingsButton,
    this.goToSettingsDescription,
  });

  final String fingerprintHint;
  final String fingerprintNotRecognized;
  final String fingerprintSuccess;
  final String cancelButton;
  final String signInTitle;
  final String fingerprintRequiredTitle;
  final String goToSettingsButton;
  final String goToSettingsDescription;

  Map<String, String> get args {
    return <String, String>{
      'fingerprintHint': fingerprintHint ?? androidFingerprintHint,
      'fingerprintNotRecognized':
          fingerprintNotRecognized ?? androidFingerprintNotRecognized,
      'fingerprintSuccess': fingerprintSuccess ?? androidFingerprintSuccess,
      'cancelButton': cancelButton ?? androidCancelButton,
      'signInTitle': signInTitle ?? androidSignInTitle,
      'fingerprintRequired':
          fingerprintRequiredTitle ?? androidFingerprintRequiredTitle,
      'goToSetting': goToSettingsButton ?? goToSettings,
      'goToSettingDescription':
          goToSettingsDescription ?? androidGoToSettingsDescription,
    };
  }
}

/// iOS side authentication messages.
///
/// Provides default values for all messages.
class IOSAuthMessages {
  const IOSAuthMessages({
    this.lockOut,
    this.goToSettingsButton,
    this.goToSettingsDescription,
    this.cancelButton,
  });

  final String lockOut;
  final String goToSettingsButton;
  final String goToSettingsDescription;
  final String cancelButton;

  Map<String, String> get args {
    return <String, String>{
      'lockOut': lockOut ?? iOSLockOut,
      'goToSetting': goToSettingsButton ?? goToSettings,
      'goToSettingDescriptionIOS':
          goToSettingsDescription ?? iOSGoToSettingsDescription,
      'okButton': cancelButton ?? iOSOkButton,
    };
  }
}

// Strings for local_authentication plugin. Currently supports English.
// Intl.message must be string literals.
String get androidFingerprintHint => Intl.message('Lấy dấu vân tay',
    desc: 'Hint message advising the user how to scan their fingerprint. It is '
        'used on Android side. Maximum 60 characters.');

String get androidFingerprintNotRecognized =>
    Intl.message('Dấu vân tay chưa được xác nhận, thử lại!',
        desc: 'Message to let the user know that authentication was failed. It '
            'is used on Android side. Maximum 60 characters.');

String get androidFingerprintSuccess => Intl.message('Đã xác thực thành công!',
    desc: 'Message to let the user know that authentication was successful. It '
        'is used on Android side. Maximum 60 characters.');

String get androidCancelButton => Intl.message('Hủy bỏ',
    desc: 'Message showed on a button that the user can click to leave the '
        'current dialog. It is used on Android side. Maximum 30 characters.');

String get androidSignInTitle => Intl.message('Xác thực dấu vân tay',
    desc: 'Message showed as a title in a dialog which indicates the user '
        'that they need to scan fingerprint to continue. It is used on '
        'Android side. Maximum 60 characters.');

String get androidFingerprintRequiredTitle {
  return Intl.message('Yêu cầu dấu vân tay',
      desc: 'Message showed as a title in a dialog which indicates the user '
          'fingerprint is not set up yet on their device. It is used on Android'
          ' side. Maximum 60 characters.');
}

String get goToSettings => Intl.message('Đến đến cài đặt',
    desc: 'Message showed on a button that the user can click to go to '
        'settings pages from the current dialog. It is used on both Android '
        'and iOS side. Maximum 30 characters.');

String get androidGoToSettingsDescription => Intl.message(
    'Vân tay không được thiết lập trên thiết bị của bạn. Đi đến '
    '\'Cài đặt > Bảo mật\' để thêm dấu vân tay của bạn.',
    desc: 'Message advising the user to go to the settings and configure '
        'fingerprint on their device. It shows in a dialog on Android side.');

String get iOSLockOut => Intl.message(
    'Biometric authentication is disabled. Please lock and unlock your screen to '
    'enable it.',
    desc:
        'Message advising the user to re-enable biometrics on their device. It '
        'shows in a dialog on iOS side.');

String get iOSGoToSettingsDescription => Intl.message(
    'Biometric authentication is not set up on your device. Please either enable '
    'Touch ID or Face ID on your phone.',
    desc:
        'Message advising the user to go to the settings and configure Biometrics '
        'for their device. It shows in a dialog on iOS side.');

String get iOSOkButton => Intl.message('Đồng ý',
    desc: 'Message showed on a button that the user can click to leave the '
        'current dialog. It is used on iOS side. Maximum 30 characters.');
